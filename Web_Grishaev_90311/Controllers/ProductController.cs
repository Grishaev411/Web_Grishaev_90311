using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Grishaev_90311.Extensions;
using Web_Grishaev_90311.Models;
using WebLabsV05.DAL.Entities;
using WebLabsV05.DAL.Data;

namespace Web_Grishaev_90311.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
       
        int _pageSize;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            _pageSize = 3;
            //SetupData();
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        
        {
           var dishesFiltered = _context.Dishes 
          .Where(d => !group.HasValue || d.DishGroupId == group.Value);

            // Поместить список групп во ViewData 
            ViewData["Groups"] = _context.DishGroups;
           

            // Получить id текущей группы и поместить в TempData 
            ViewData["CurrentGroup"] = group ?? 0;
            
            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
           
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
       
    }
       
        }
    }

