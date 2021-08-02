using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
using System;

namespace My_Classes_App.Controllers
{
    //home controller

    public class HomeController : Controller
    {
        private IRepository<Class> data { get; set; }
        public HomeController(IRepository<Class> rep) => data = rep;

        public ViewResult Index()
        {
            var random = data.Get(new QueryOptions<Class>
            {
                OrderBy = c => Guid.NewGuid()
            });

            return View(random);
        }
    }
}