using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class MovieInfo
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Please select a category")]
        public int CategoryID { get; set; }
        //Add foreign key here
        public Category Category { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a year")]
        public string? Year { get; set; }
        [Required(ErrorMessage = "Please enter a director")]
        public string? Director { get; set; }
        [Required(ErrorMessage = "Please enter a rating")]
        public string? Rating { get; set; }
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }

    }
}
