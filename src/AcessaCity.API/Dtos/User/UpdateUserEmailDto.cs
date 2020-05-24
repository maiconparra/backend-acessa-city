using System;

namespace AcessaCity.API.Dtos.User
{
    public class UpdateUserDataDto
    {
        public Guid UserId { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}