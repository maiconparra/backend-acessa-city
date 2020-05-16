namespace AcessaCity.Business.Dto.City.User
{
    public class UserCreateDto
    {
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }
}