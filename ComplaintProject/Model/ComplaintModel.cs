namespace ComplaintProject.Model
{
    public class ComplaintModel
    {
        public long ComplaintId { get; set; }
        public string ComplaintTextAr { get; set; }
        public string ComplaintTextEn { get; set; }
        public string? AttachmentPath { get; set; } = null;
        public bool? isDelete { get; set; } = false;
        public string? AssignUsersId { get; set; } = null;
        public int? StatusId { get; set; } = 1;
        public long? UserId { get; set; }
    }
}
