using Z_ParkLib;

namespace Z_ParkRest.Model

{
    public static class UserConverter
    {
        public static User DTO2User(UserDTO dto)
        {
            User user = new User
            {
                LicensePlate = dto.LicensePlate,
                Name = dto.Name,
                Surname = dto.Surname,
                Mail = dto.Mail,
                Username = dto.Username,
                Password = dto.Password
            };

            return user;
        }
    }
}