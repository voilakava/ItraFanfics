using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace cours1test.ViewModels
{
    public class EditFandomModel
    { 

        public int Id { get; set; }

        [Display(Name = "Название фандома")]
        public string Title { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        public IFormFile UploadedFile { get; set; }
    }
}
