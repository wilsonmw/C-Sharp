using System.ComponentModel.DataAnnotations;

namespace loginreg.Models
{
    public class User
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
        [Compare("Password",ErrorMessage="Confirm Password field must match Password field.")]
        [Display(Name = "Confirm Password")]
        public string PWConfirm {get; set;}
        public User(){

        }    
    }
}
