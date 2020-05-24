using System;
using System.Collections.Generic;

namespace AcessaCity.Business.Dto.User
{
    public class UserCreateDto
    {
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string PhotoUrl { get; set; }
        public bool Disabled { get; set; }
        public Guid CityHallId { get; set; }
        public List<string> Roles { get; set; }
    }
}