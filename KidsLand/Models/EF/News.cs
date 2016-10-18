using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KidsLand.Models.EF
{
    public class News
    {
        public int NewsId { get; set; }
        [Required(ErrorMessage = "Error")]
        [Display(Name = "Заголовок")]
        [MinLength(1, ErrorMessage = "Это поле не может быть пустым")]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "Error")]
        [MinLength(1,ErrorMessage = "Это поле не может быть пустым")]
        [Display(Name = "Содержимое новости")]
        public string NewsBody { get; set; }
        [Display(Name = "КДПВ")]
        public string NewsImg { get; set; }
        [Display(Name = "Дата новости")]
        public DateTime NewsDate { get; set; }
    }
}