using Z_ParkLib.Model;

namespace Z_ParkLib.repositories
{
    public class UserRepository : IUserRepository
    {
        // Instansfelter
        private readonly List<User> _users;

        public UserRepository(bool mockData = false)
        {
            _users = new List<User>();

            if (mockData)
            {
                PopulateUsers();
            }
        }

        private void PopulateUsers()
        {
            Add(new User("ABC1234", "John", "Doe", "john.doe@example.com", "johndoe", "password123"));
            Add(new User("XYZ5678", "Jane", "Smith", "jane.smith@example.com", "janesmith", "securepass456"));
            Add(new User("QWE7890", "Chris", "Johnson", "chris.johnson@example.com", "chrisj", "qwerty987"));
        }

        public List<User> GetAll()
        {
            return new List<User>(_users);
        }

        public User GetById(string licensePlate)
        {
            User? user = _users.Find(u => u.Licenseplate == licensePlate);

            if (user == null)
            {
                throw new KeyNotFoundException($"Bruger med nummerplade '{licensePlate}' ikke fundet.");
            }

            return user;
        }

        public User Add(User user)
        {
            if (_users.Any(u => u.Licenseplate == user.Licenseplate))
            {
                throw new ArgumentException($"Bruger med nummerplade '{user.Licenseplate}' eksisterer allerede.");
            }

            _users.Add(user);
            return user;
        }

        public User Update(string licensePlate, User updatedUser)
        {
            User existingUser = GetById(licensePlate); // throw KeyNotFoundException
            int index = _users.IndexOf(existingUser);
            _users[index] = updatedUser;
            return updatedUser;
        }

        public User Delete(string licensePlate)
        {
            User user = GetById(licensePlate); // throw KeyNotFoundException
            _users.Remove(user);
            return user;
        }

        public bool ValidateUser(string licensePlate, string password)
        {
            User? user = _users.FirstOrDefault(u => u.Licenseplate == licensePlate);
            return user != null && user.Password == password;
        }
    }
}
