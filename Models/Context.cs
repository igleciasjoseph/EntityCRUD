using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
namespace CRUD.Models
{
    public class DishContext : DbContext 
    {
        public DishContext(DbContextOptions options) : base(options) {}
            public DbSet<Dish> Dishes{get;set;} 

        public Dish GetDishById(int DishId) {
            return Dishes.Where(d => d.DishId == DishId).FirstOrDefault();
        }

        public void Update(Dish d) {
            Dish result = GetDishById(d.DishId);
            if(result != null) {
                result.Name = d.Name;
                result.Chef = d.Chef;
                result.Description = d.Description;
                result.Calories = d.Calories;
                result.Tastiness = d.Tastiness;
                result.UpdatedAt = DateTime.Now;
            }
            SaveChanges();
        }

        public void DeleteById(int DishId)
        {
            Remove(GetDishById(DishId));
            SaveChanges();
        }
    }
}