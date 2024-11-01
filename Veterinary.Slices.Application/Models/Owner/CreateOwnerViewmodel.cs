
using System.ComponentModel.DataAnnotations;

namespace Veterinary.Slices.Application.Models.Owner
{
    public class CreateOwnerViewmodel
    {
        [Required(ErrorMessage = "Field is required")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Field is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field is required")]
        [MinLength(4,ErrorMessage = "Field must be at least 4 characters long")]
        public string? PhoneNumber { get; set; }
 
        [MinLength(4, ErrorMessage = "Field must be at least 4 characters long")]
        public string? AlternativePhoneNumber { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Identification { get; set; } = string.Empty;
    }
}