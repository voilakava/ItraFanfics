using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using cours1test.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cours1test.ViewModels
{
    public class AddFanficModel
    {
        //public SelectList FandomList { get; set;}
        
        [Required(ErrorMessage = "Нет названия фанфика")]
        [Display(Name = "Название фанфика")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Нет описания фанфика")]
        [Display(Name = "Описание фанфика")]
        public string Description { get; set; }
         
        //public string FText { get; set; }

        [Display(Name = "Добавить главу")]
        public ICollection<Chapter> Chapters { get; set; }
         
        public string AuthorId { get; set; }

        //[Required(ErrorMessage = "Не указан фандом")]
        public Fandom Fandom { get; set; }
        public string FandomName { get; set; }

        [Required(ErrorMessage = "Не указаны категории")]
        public Category Category { get; set; }
    }
}
