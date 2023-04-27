
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace WebApp.Models
{
    public class Coach // тренер
    {
        public Coach()
        {
            Service = new HashSet<Service>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public int ServiceID { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Required]
        [StringLength(50)]
        public string Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        public virtual ICollection<Service> Service { get; set; }
    }
}

