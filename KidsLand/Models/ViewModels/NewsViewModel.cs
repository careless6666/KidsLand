using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using KidsLand.Models.EF;
using PagedList;

namespace KidsLand.Models.ViewModels
{
    public class NewsViewModel
    {
        public List<News> NewsList { get; set; }
        public IPagedList<News> NewsListPages { get; set; }
        public News News { get; set; }

        public int NewsId { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Заголовок")]
        [MinLength(1, ErrorMessage = "Это поле не может быть пустым")]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Содержимое новости")]
        [MinLength(1, ErrorMessage = "Это поле не может быть пустым")]
        public string NewsBody { get; set; }
        
        [Display(Name = "КДПВ")]
        public HttpPostedFileWrapper NewsImg { get; set; }

        public string NewsImgStr { get; set; }
        
        [Display(Name = "Дата новости")]
        public DateTime NewsDate { get; set; }
    }
}