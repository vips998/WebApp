using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.DTO
{
    public class ServiceDTO  // Услуга
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public int CoachID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
