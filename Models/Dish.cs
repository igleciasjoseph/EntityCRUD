using System;
using System.ComponentModel.DataAnnotations;
namespace CRUD.Models
{
    public class Dish {
        [Key]
        [Required(ErrorMessage="Field Must Not Be Empty")]
        public int DishId{get;set;}
        [Required(ErrorMessage = "Field Must Not Be Empty")]
        public string Name{get;set;}
        [Required(ErrorMessage = "Field Must Not Be Empty")]
        public string Chef{get;set;}
        [Required(ErrorMessage = "Field Must Not Be Empty and Must be in between 1 and 6")]
        [Range(0,6)]
        public int Tastiness{get;set;}
        [Required(ErrorMessage = "Field Must Not Be Empty")]
        [Range(1,2000)]
        public int Calories{get;set;}
        [Required(ErrorMessage = "Field Must Not Be Empty")]
        public string Description{get;set;}

        public DateTime CreatedAt {get;set;}= DateTime.Now;
        public DateTime UpdatedAt {get;set;}= DateTime.Now;
    }
}