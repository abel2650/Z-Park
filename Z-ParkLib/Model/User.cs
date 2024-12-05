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
            if (string.IsNullOrWhiteSpace(value) || value.Length != 7) 
            {
                throw new ArgumentException("Nummerplade skal være 7 tegn.");
            }
            _licenseplate = value; 
        } 
    }

    public string Name  
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
            {
                throw new ArgumentException("Navn skal være mere end 2 tegn.");
            }

            // Tjek for ugyldige tegn
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[a-zA-ZæøåÆØÅ]+$"))
            {
                throw new ArgumentException("Navn må kun indeholde bogstaver.");
            }

            _name = value;
        }

    }

    public string Surname  
    {
        get => _surname;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
            {
                throw new ArgumentException("Efternavn skal være mere end 2 tegn.");
            }

            // Tjek for ugyldige tegn
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[a-zA-ZæøåÆØÅ]+$"))
            {
                throw new ArgumentException("Efternavn må kun indeholde bogstaver.");
            }

            _surname = value;
        }
    }

    public string Mail
    {
        get => _mail;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email må ikke være tom.");
            }

            // Brug en regex til at validere emailens format
            if (!System.Text.RegularExpressions.Regex.IsMatch(
                    value,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ArgumentException("Email skal have et gyldigt format (f.eks. navn@domæne.dk).");
            }

            _mail = value;
        }
    }

    public string Username  
    {
        get => _username;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new ArgumentException("Brugernavn skal være mere end 3 tegn.");
            }
            _username = value;
        }
    }
    public string Password 
    {
        get => _password;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
            {
                throw new ArgumentException("Kodeordet skal være mere end 5 tegn.");
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

    public User() : this("ACH3456", "Dummy", "Nielsen", "Dummy_911@hotmail.com", "DummyNielsen", "123456789") { }

    public override string ToString()
    {
        return
            $"{nameof(_licenseplate)}: {_licenseplate}, {nameof(_name)}: {_name}, {nameof(_surname)}: {_surname}, {nameof(_mail)}: {_mail}, {nameof(_username)}: {_username}, {nameof(_password)}: {_password}, {nameof(Licenseplate)}: {Licenseplate}, {nameof(Name)}: {Name}, {nameof(Surname)}: {Surname}, {nameof(Mail)}: {Mail}, {nameof(Username)}: {Username}, {nameof(Password)}: {Password}";
    }
}