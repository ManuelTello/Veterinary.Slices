using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Veterinary.Slices.Application.Data.Entities;

namespace Veterinary.Slices.Application.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Owner> Owners { get; set; }
        
        public DbSet<Pet> Pets { get; set; }
        
        public DbSet<OwnerPet> OwnersPets { get; set; }
        
        public DbSet<Consultation> Consultations { get; set; }
    }
}
