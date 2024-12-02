namespace Z_ParkLib;

public class User
{
    

    // instans felter
    private string _licensePlate;
    private string _name;
    private string _surname;
    private string _mail;
    private string _username;
    private string _password;

    // properties
    public string LicensePlate 
    { 
        get { return _licensePlate; } 
        set 
        { 
            if (value.ToString().Length != 7) 
            {
                throw new ArgumentException("Nummerplade skal være 7 tegn!");
            }
            _licensePlate = value; 
        } 
    }

    public string Name  
    { 
        get { return _name; } 
        set 
        { 
            _name = value; 
        } 
    }

    public string Surname  
    { 
        get { return _surname; } 
        set 
        { 
            _surname = value; 
        } 
    }

    public string Mail  
    { 
        get { return _mail; } 
        set 
        { 
            _mail = value; 
        } 
    }
    public string Username  
    { 
        get { return _username; } 
        set 
        { 
            _username = value; 
        } 
    }
    public string Password 
    { 
        get { return _password; } 
        set 
        { 
            if (value.Length <= 8)
            {
                throw new ArgumentException("Kode skal være 8 tegn eller mindre!");
            }
            _password = value; 
        } 
    }

    public User(string licenseplate, string name, string surname, string mail, string username, string password)
    {
        LicensePlate = licenseplate;
        Name = name;
        Surname = surname;
        Mail = mail;
        Username = username;
        Password = password;
    }

    public User() : this("ACH3456", "Dummy", "Dummy Nielsen", "Dummy_911@hotmail.com", "DummyNielsen", "123456789") { }

    public override string ToString()
    {
        return $"{Name} {Surname}, Username: {Username}, Email: {Mail}, License Plate: {LicensePlate}";
    }
}