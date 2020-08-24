using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Web_Grishaev_90311.Models;

namespace Web_Grishaev_90311.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Text"] = "Лабораторная работа 2";
            ViewData["Lst"] = new SelectList(_listDemo, "ListItemValue", "ListItemText");
            return View();
        }
        private List<ListDemo> _listDemo;
        public class ListDemo
        {
            public int ListItemValue { get; set; }
            public string ListItemText { get; set; }
        }
        
        public HomeController()
        {
            _listDemo = new List<ListDemo>
            {
                new ListDemo{ ListItemValue=1, ListItemText="Элемент 1"},
                new ListDemo{ ListItemValue=2, ListItemText="Элемент 2"},
                new ListDemo{ ListItemValue=3, ListItemText="Элемент 3"},
                new ListDemo{ ListItemValue=4, ListItemText="Элемент 4"}
            };
        }
        
    }
}
