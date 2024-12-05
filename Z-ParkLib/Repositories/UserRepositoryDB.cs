using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Z_ParkLib.repositories;

public class UserRepositoryDB : IUserRepository
{
    private EFUserContext _db;

    public UserRepositoryDB(EFUserContext dbContext)
    {
        _db = dbContext;
    }


    public User Add(User newUser)
    {
    newUser.Licenseplate = "0";
    _db.Users.Add(newUser);
    _db.SaveChanges();

    return newUser;
    }

    public User Delete(string licensePlate)
    {
        User u = GetById(licensePlate);
        _db.Users.Remove(u);
        _db.SaveChanges();

        return u;
    }

    
    public List<User> GetAll()
    {
        return new List<User>(_db.Users);
    }

    public User GetById(string licensePlate)
    {
        User? user = _db.Users.FirstOrDefault(u => u.Licenseplate == licensePlate);

        if (user == null)
        {
            throw new KeyNotFoundException($"User with license plate {licensePlate} not found.");
        }

        return user;
    }

    public User Update(string licensePlate, User updatedUser)
    {
        User user = GetById(licensePlate);
        user.Licenseplate = updatedUser.Licenseplate;

        user.Name = updatedUser.Name;
        user.Surname = updatedUser.Surname;
        user.Mail = updatedUser.Mail;
        user.Username = updatedUser.Username;
        user.Password = updatedUser.Password;


        _db.SaveChanges();
        return user;
    }
}
