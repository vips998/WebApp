using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Xml;

namespace WebApp.Models
{
    public class Service  // Услуга
    {
        public Service()
        {
            Record = new HashSet<Record>();
        }

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

        public virtual ICollection<Record> Record { get; set; }
        public virtual Coach Coach { get; set; }
    }
}
