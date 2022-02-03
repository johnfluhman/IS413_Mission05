using System;
using System.ComponentModel.DataAnnotations;

namespace Mission05.Models
{
    public class MovieSubmission
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        //Build foreign key relationship
        [Required(ErrorMessage = "Category must be populated")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
