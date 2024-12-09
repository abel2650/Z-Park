using Z_ParkLib.Model;

namespace Z_ParkRest.Model

{
    public static class UserConverter
    {
        public static User DTO2User(UserDTO dto)
        {
            User user = new User();

            user.Licenseplate = dto.Licenseplate;
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.Mail = dto.Mail;
            user.Username = dto.Username;
            user.Password = dto.Password;
            return user;
        }
    }
}
