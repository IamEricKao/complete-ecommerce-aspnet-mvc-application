using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewMovieVM
    {
        [Display(Name = "電影名稱：")]
        [Required(ErrorMessage = "電影名稱必填")]
        public string Name { get; set; }

        [Display(Name = "介紹：")]
        [Required(ErrorMessage = "介紹必填")]
        public string Description { get; set; }

        [Display(Name = "價格：")]
        [Required(ErrorMessage = "價格必填")]
        public double Price { get; set; }

        [Display(Name = "圖片：")]
        [Required(ErrorMessage = "圖片不得空白")]
        public string ImageURL { get; set; }

        [Display(Name = "上映日期：")]
        [Required(ErrorMessage = "上映日期必填")]
        public DateTime StartDate { get; set; }

        [Display(Name = "下檔日期：")]
        [Required(ErrorMessage = "下檔日期必填")]
        public DateTime EndDate { get; set; }

        [Display(Name = "類型：")]
        [Required(ErrorMessage = "類型必填")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [Display(Name = "演員：")]
        [Required(ErrorMessage = "演員必填")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "電影院：")]
        [Required(ErrorMessage = "電影院必填")]
        public int CinemaId { get; set; }

        [Display(Name = "導演：")]
        [Required(ErrorMessage = "導演必填")]
        public int ProducerId { get; set; }
    }
}