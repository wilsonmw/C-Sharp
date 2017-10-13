using System.ComponentModel.DataAnnotations;

namespace wall.Models
{
    public class Comment
    {
        [Required]
        [MaxLength(500)]
        [MinLength(5)]
        public string commentContent {get; set;}

        public Comment(){

        }

    }
}