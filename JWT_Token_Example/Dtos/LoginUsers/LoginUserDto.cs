namespace Authentication_Login.Dtos.LoginUsers
{
    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
    }
}
