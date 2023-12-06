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
        public string Logo { get; set; }

        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Display(Name = "簡介")]
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}