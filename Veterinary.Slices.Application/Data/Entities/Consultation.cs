using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Slices.Application.Data.Entities
{
    [Table("consultations")]
    public class Consultation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",Order = 0)]
        public Guid Id { get; set; } 
        
        [ForeignKey("pets")]
        [Column("pet_id",Order = 1)]
        public Guid PetId { get; set; }
        
        [Column("content", Order = 2)]
        public string? Content { get; set; }
        
        [Column("annotations", Order = 3)]
        public string? Annotations { get; set; }

        [Column("type_of", Order = 4)]
        public string Typeof { get; set; } = string.Empty;
        
        [Column("date_created", Order = 5)]
        public DateTime DateCreated { get; set; }
        
        [Column("crated_by", Order = 6)]
        public string CreatedBy { get; set; } = string.Empty;
        
        public Pet Pet { get; set; }
    }
}

