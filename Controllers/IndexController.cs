using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD.Models;


namespace CRUD.Controllers
{
    public class IndexController : Controller
    {
        private DishContext dbContext;

        public IndexController(DishContext context) {
            dbContext = context;
        }


        [HttpGet("")]
        public IActionResult Index() {
            ViewBag.Dish = dbContext.Dishes;
            return View();
        }

        [HttpGet("new")]
        public IActionResult NewDish() {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish) {
            if(ModelState.IsValid) {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return Redirect("/");
            } else {
                return View("NewDish");
            }
        }

        [HttpGet("dish/{DishId}")]
        public IActionResult Id(int DishId) {
            return View(dbContext.GetDishById(DishId));
        }

        [HttpGet("edit/{DishId}")]
        public IActionResult Edit(Dish d) {
            return View(d);
        }

        [HttpPost("update/{DishId}")]
        public IActionResult EditDish(int DishId, Dish d) {
            dbContext.Update(d);
            return Redirect("/");
        }

        [HttpPost("delete/{DishId}")]
        public IActionResult Delete(int DishId)
        {
            dbContext.DeleteById(DishId);
            return Redirect("/");
        }

    }
}