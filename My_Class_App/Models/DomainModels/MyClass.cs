using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace My_Classes_App.Models
{
    public class MyClass : IClass
    {
        private const string CartKey = "mycart";
        private const string CountKey = "mycount";

        private List<ClassItem> items { get; set; }
        private List<ClassItemDTO> storedItems { get; set; }

        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public MyClass(IHttpContextAccessor ctx)
        {
            session = ctx.HttpContext.Session;
            requestCookies = ctx.HttpContext.Request.Cookies;
            responseCookies = ctx.HttpContext.Response.Cookies;
            items = new List<ClassItem>(); // needed for test method to run
        }

        public void Load(IRepository<Class> data)
        {
            items = session.GetObject<List<ClassItem>>(CartKey);
            if (items == null) {
                items = new List<ClassItem>();
                storedItems = requestCookies.GetObject<List<ClassItemDTO>>(CartKey);
            }
            if (storedItems?.Count > items?.Count) {
                foreach (ClassItemDTO storedItem in storedItems) {
                    var book = data.Get(new QueryOptions<Class> {
                        Includes = "ClassTeachers.Teacher, ClassType",
                        Where = b => b.ClassId == storedItem.ClassId
                    });
                    if (book != null) {
                        var dto = new ClassDTO();
                        dto.Load(book);

                        ClassItem item = new ClassItem {
                            Class = dto,
                            Quantity = storedItem.Quantity
                        };
                        items.Add(item);
                    }
                }
                Save();
            }
        }

        public double Subtotal => items.Sum(i => i.Subtotal);
        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetInt32(CountKey);
        public IEnumerable<ClassItem> List => items;

        public ClassItem GetById(int id) => 
            items.FirstOrDefault(ci => ci.Class.ClassId == id);

        public void Add(ClassItem item) {
            var itemInCart = GetById(item.Class.ClassId);
            
            if (itemInCart == null) {
                items.Add(item);
            }
            else {  
                itemInCart.Quantity += 1;
            }
        }

        public void Edit(ClassItem item)
        {
            var itemInCart = GetById(item.Class.ClassId);
            if (itemInCart != null) {
                itemInCart.Quantity = item.Quantity;
            }
        }

        public void Remove(ClassItem item) => items.Remove(item);
        public void Clear() => items.Clear();
        
        public void Save() {
            if (items.Count == 0) {
                session.Remove(CartKey);
                session.Remove(CountKey);
                responseCookies.Delete(CartKey);
                responseCookies.Delete(CountKey);
            }
            else {
                session.SetObject<List<ClassItem>>(CartKey, items);
                session.SetInt32(CountKey, items.Count);
                responseCookies.SetObject<List<ClassItemDTO>>(CartKey, items.ToDTO());
                responseCookies.SetInt32(CountKey, items.Count);
            }
        }
    }
}
