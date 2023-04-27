
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace WebApp.Models
{
    public class User: IdentityUser<int> // пользователь
    {
        public User()
        {
            Record = new HashSet<Record>();
        }

        [Required]
        [StringLength(50)]
        public string? Nickname { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [Column(TypeName = "money")]
        public int? Balance { get; set; }

        [StringLength(50)]
        public string? FIO { get; set; }

        [StringLength(50)]
        public string? Age { get; set; }

        [StringLength(50)]
        public string? Telephone { get; set; }

        [StringLength(50)]
        public string? Passport { get; set; }

        public virtual ICollection<Record> Record { get; set; }

    }
}
