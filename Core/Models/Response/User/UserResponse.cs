namespace Core.Models.Response.User
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? BirthDate { get; set; }
        public string? Email { get; set; }

        public ICollection<string>? Roles { get; set; }
    }
}
