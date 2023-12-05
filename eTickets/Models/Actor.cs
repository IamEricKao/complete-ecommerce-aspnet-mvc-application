using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "照片")]
        [Required(ErrorMessage = "照片不可空白")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名必填")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "姓名長度要介於 3 到 50 個字之間")]
        public string FullName { get; set; }

        [Display(Name = "介紹")]
        [Required(ErrorMessage = "介紹必填")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}