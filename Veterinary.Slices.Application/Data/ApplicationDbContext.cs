using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Veterinary.Slices.Application.Data.Entities;

namespace Veterinary.Slices.Application.Data
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
    }

    public class VeterinaryContext:DbContext
    {
        public VeterinaryContext(DbContextOptions<VeterinaryContext> options) : base(options) { } 
        
         public DbSet<Owner> Owners { get; set; }
         
         public DbSet<Pet> Pets { get; set; }
         
         public DbSet<OwnerPet> OwnersPets { get; set; }
         
         public DbSet<Consultation> Consultations { get; set; }       
    }
}
