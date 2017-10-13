using System.ComponentModel.DataAnnotations;

namespace wall.Models
{
    public class User
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}


        public User(){
        }
    }

    public class ValidateUser
    {
        [Required]
        [MinLength(2)]
        public string FirstName {get; set;}
        [Required]
        [MinLength(2)]
        public string LastName {get; set;}
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [MinLength(8)]
        public string Password {get; set;}
        [Required]
        [Compare("Password", ErrorMessage="Confirm Password field must match Password field.")]
        [Display(Name= "Confirm Password")]
        public string PwConfirm {get; set;}

    }
    
}