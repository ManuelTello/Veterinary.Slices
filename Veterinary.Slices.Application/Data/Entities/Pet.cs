using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Slices.Application.Data.Entities
{
    
    [Table("pets")]
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 0)]
        public Guid Id { get; set; }   
        
        [Column("full_name", Order = 1)] 
        [MaxLength(250)]
        public string FullName { get; init; } = string.Empty;
        
        [Column("breed", Order = 2)]
        [MaxLength(100)]
        public string? Breed { get; init; } = string.Empty;
        
        [Column("gender", Order = 3)]
        [MaxLength(10)]
        public string Gender { get; init; } = string.Empty;
        
        [Column("weight", Order = 4)]
        public float Weight { get; init; }
        
        [Column("date_of_birth", Order = 5)]
        public DateTime DateOfBirth { get; init; }

        public List<OwnerPet> OwnersPets { get; } = [];

        public ICollection<Consultation> Consultations { get; } = new List<Consultation>();
    }
}

