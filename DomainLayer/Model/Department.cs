using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Model
{
    public class Department
    {
        [Key]
        public long DepartmentId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool? isDelete { get; set; } = false;
        public ICollection<Users> Users { get; set; }

    }
}
