using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "介紹")]
        public string Description { get; set; }

        [Display(Name = "價錢：")]
        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        [Display(Name = "上映日期：")]
        public DateTime StartDate { get; set; }

        [Display(Name = "下檔日期：")]
        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        public int CinemaId { get; set; }

        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}