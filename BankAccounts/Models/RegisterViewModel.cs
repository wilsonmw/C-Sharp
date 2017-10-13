using System.ComponentModel.DataAnnotations;
namespace BankAccounts.Models
{
    public class RegisterViewModel
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
        [Compare("Password", ErrorMessage="Confirm Password field and Password field must match.")]
        public string PwConfirm {get; set;}

        public RegisterViewModel(){
            
        }
    }
}