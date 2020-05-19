using System;

namespace AcessaCity.API.Dtos.User
{
    public class UpdateUserProfilePhoto
    {
        public Guid UserId { get; set; }
        public string PhotoURL { get; set; }
    }
}