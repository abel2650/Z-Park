using Z_ParkLib.Model;

namespace Z_ParkLib.repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(string licensePlate);
        User Add(User user);
        User Update(string licensePlate, User updatedUser);
        User Delete(string licensePlate);
       // bool ValidateUser(string username, string password);
    }
}
