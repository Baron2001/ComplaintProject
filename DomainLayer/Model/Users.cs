using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Model
{
    public class Users
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool? isDelete { get; set; } = false;
        // Additional user information fields can be added here

        [ForeignKey("Roles")]
        public int? RoleId { get; set; } = 2; // As User
        public virtual Roles? Roles { get; set; }

        public ICollection<Complaint> Complaints { get; set; }
    }
}
