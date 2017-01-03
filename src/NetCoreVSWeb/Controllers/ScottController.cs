using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreVSWeb.Controllers
{
    public class ScottController : Controller
    {
        public ViewResult Index()
        {
            var scottIndex = new ScottIndex()
            {
                Name = "Scott",
                Age = 20
            };
            return View(scottIndex);
        }
    }

    public class ScottIndex
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
