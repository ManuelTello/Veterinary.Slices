using MediatR;

namespace Veterinary.Slices.Application.Features.Owners.CreateOwner
{
    public class CreateOwnerCommand:IRequest
    {
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        
        public string PhoneNumber { get; set; } = string.Empty; 
        
        public string? AlternativePhoneNumber { get; set; }
        
        public string Identification { get; set; } = string.Empty;
    }
}

