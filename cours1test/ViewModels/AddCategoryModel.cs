using System;
using System.ComponentModel.DataAnnotations;

namespace cours1test.ViewModels
{
    public class AddCategoryModel
    {
        [Required]
        [Display(Name = "Категория")]
        public string Name { get; set; }

         
    }
}
