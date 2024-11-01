using MediatR;
using Veterinary.Slices.Application.Data;
using Veterinary.Slices.Application.Data.Entities;

namespace Veterinary.Slices.Application.Features.Owners.CreateOwner
{
    public class CreateOwnerCommandHandler:IRequestHandler<CreateOwnerCommand>
    {
        private readonly VeterinaryContext _databaseContext;

        public CreateOwnerCommandHandler(VeterinaryContext context)
        {
            this._databaseContext = context;
        }
        
        public async Task Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            Owner owner = new Owner()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                AlternativePhoneNumber = request.AlternativePhoneNumber,
                Identification = request.Identification,
                DateAddedToSystem = DateTime.Now,
            };
            await this._databaseContext.Owners.AddAsync(owner, cancellationToken);
            await this._databaseContext.SaveChangesAsync(cancellationToken);
        }
    }
}   

