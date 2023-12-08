using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "商標")]
        [Required(ErrorMessage = "商標不可空白")]
        public string Logo { get; set; }

        [Display(Name = "名稱")]
        [Required(ErrorMessage = "名稱必填")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "名稱長度必須介於 3 到 10個字之間")]
        public string Name { get; set; }

        [Display(Name = "簡介")]
        [Required(ErrorMessage = "簡介必填")]
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}