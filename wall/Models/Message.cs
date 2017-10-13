using System.ComponentModel.DataAnnotations;

namespace wall.Models
{
    public class Message
    {
        [Required]
        [MaxLength(1000)]
        [MinLength(5)]
        public string Content {get; set;}

        public Message(){

        }

    }
}