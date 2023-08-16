using Authentication_Login.Models.Auditable;

namespace Authentication_Login.Dtos.Users
{
    public class GetUserDto : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Document { get; set; }
    }
}
