using System;
using System.ComponentModel.DataAnnotations;

namespace cours1test.ViewModels
{
    public class AddFandomModel
    {
        [Required]
        [Display(Name = "Название фандома")]
        public string Titile { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

    }
}
