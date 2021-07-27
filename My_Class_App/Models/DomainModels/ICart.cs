using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public interface ICart
    {
        void Load(IRepository<Class> data);
        double Subtotal { get; }
        int? Count { get; }
        IEnumerable<CartItem> List { get; }
        CartItem GetById(int id);
        void Add(CartItem item);
        void Edit(CartItem item);
        void Remove(CartItem item);
        void Clear();
        void Save();
    }
}