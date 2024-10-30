using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Slices.Application.Data.Entities
{
    [Table("owners")]
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 0)]
        public Guid Id { get; init; }
        
        [Column("first_name", Order = 1)]
        [MaxLength(250)]
        public string FirstName { get; init; } = string.Empty;
        
        [Column("last_name", Order = 2)]
        [MaxLength(250)]
        public string LastName { get; init; } = string.Empty;
        
        [Column("phone_number", Order = 3)]
        [MaxLength(20)]
        public string PhoneNumber { get; init; } = string.Empty;
        
        [Column("alternative_phone_number", Order = 4)]
        [MaxLength(20)]
        public string AlternativePhoneNumber { get; init; } = string.Empty;
        
        [Column("identification", Order = 5)]
        [MaxLength(20)]
        public string Identification { get; init; } = string.Empty;
        
        [Column("date_added_to_system", Order = 6)]
        public DateTime DateAddedToSystem { get; init; }

        public List<OwnerPet> OwnersPets { get; } = [];
    }
}

