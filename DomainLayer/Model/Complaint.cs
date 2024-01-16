using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Model
{
    public class Complaint
    {
        [Key]
        public long ComplaintId { get; set; }
        public string ComplaintTextAr { get; set; }
        public string ComplaintTextEn { get; set; }
        public string? AttachmentPath { get; set; }
        public bool? isDelete { get; set; } = false;
        public string? AssignUsersId { get; set;} = null;

        [ForeignKey("Status")]
        public int? StatusId { get; set; } = 1; //as pending 
        public virtual Status? Status { get; set; }

        [ForeignKey("Users")]
        public long? UserId { get; set; }
        public virtual Users? Users { get; set; }
    }
}
