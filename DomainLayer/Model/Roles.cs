using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Model
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleType { get; set; }
        public bool? isDelete { get; set; } = false;
    }
}
