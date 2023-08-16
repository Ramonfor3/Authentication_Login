namespace Authentication_Login.Models.Auditable
{
    public class AuditableEntity
    {
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsModified { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
