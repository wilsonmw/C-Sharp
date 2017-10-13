using System;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quote
    {
        [Required]
        [MinLength(2)]
        public string Name {get; set;}
        [Required]
        [MinLength(2)]
        public string Content {get; set;}
        public DateTime CreatedAt;
        public DateTime UpdatedAt;

        public Quote(){
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }


}