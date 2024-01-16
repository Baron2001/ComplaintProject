using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Model
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public bool? isDelete { get; set; } = false;
    }
}
