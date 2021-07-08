using System;
using System.ComponentModel.DataAnnotations;
using cours1test.Models;

namespace cours1test.ViewModels
{
    public class AddChapterModel
    {

        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Название главы")]
        public string CName { get; set; }

        [Required(ErrorMessage = "Не указан Номер главы")]
        [Display(Name = "Номер главы")] 
        public int RangeId { get; set; }

        [Required(ErrorMessage = "Нет текста главы")]
        [Display(Name = "Текст главы")]
        public string CText { get; set; }

        [Required(ErrorMessage = "Ошибка добавление главы к фанфику")]
        public int FanficId { get; set; }
    }
}
