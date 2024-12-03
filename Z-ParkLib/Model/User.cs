namespace Z_ParkLib;

public class User
{
    

    // instans felter
    private string _licenseplate;
    private string _name;
    private string _surname;
    private string _mail;
    private string _username;
    private string _password;

    // properties
    public string Licenseplate 
    { 
        get { return _licenseplate; } 
        set 
        { 
            if (value.ToString().Length != 7) 
            {
                throw new ArgumentException("Nummerplade skal være 7 tegn!");
            }
            _licenseplate = value; 
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
        Licenseplate = licenseplate;
        Name = name;
        Surname = surname;
        Mail = mail;
        Username = username;
        Password = password;
    }

    public User() : this("ACH3456", "Dummy", "Dummy Nielsen", "Dummy_911@hotmail.com", "DummyNielsen", "123456789") { }

    public override string ToString()
    {
        return
            $"{nameof(_licenseplate)}: {_licenseplate}, {nameof(_name)}: {_name}, {nameof(_surname)}: {_surname}, {nameof(_mail)}: {_mail}, {nameof(_username)}: {_username}, {nameof(_password)}: {_password}, {nameof(Licenseplate)}: {Licenseplate}, {nameof(Name)}: {Name}, {nameof(Surname)}: {Surname}, {nameof(Mail)}: {Mail}, {nameof(Username)}: {Username}, {nameof(Password)}: {Password}";
    }
}