using System;
using System.ComponentModel.DataAnnotations;

namespace restauranter.Models
{
    public class Review
    {
        public int id {get; set;}
        [Required]
        [Display(Name="Name of Restaurant")]
        public string RestaurantName {get; set;}
        [Required]
        [Display(Name="Review")]
        public string Content {get; set;}
        [Required]
        [Display(Name="Name of Reviewer")]
        public string ReviewerName {get; set;}
        [Required]
        [Display(Name="Date of Visit")]
        [MyDate(ErrorMessage="Date of Visit cannot be in the future.")]
        [DataType(DataType.Date)]
        public DateTime DateOfVisit {get; set;}
        [Required]
        public int Stars {get; set;}
        public int? HelpfulCount {get; set;}
        public int? UnhelpfulCount {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}

        public Review(){
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            HelpfulCount = 0;
            UnhelpfulCount = 0;
        }

        public class MyDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime theirDate = Convert.ToDateTime(value);
                return theirDate <= DateTime.Now;
            }
        }
    }
}