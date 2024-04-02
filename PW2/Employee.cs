namespace PW2;

public class Employee : IDisposable
{
    private static int _employeeCount;
    
    public static int EmployeeCount => _employeeCount;
    
    private string _organization = null!;
    private string _position = null!;
    private double _experience;
    private string _name = null!;
    private char _gender;
    private int _age;
    private double _salary;
    
    public Employee(string organization, string position, double experience, string name, char gender, int age, double salary)
    {
        Organization = organization;
        Position = position;
        Experience = experience;
        Name = name;
        Gender = gender;
        Age = age;
        Salary = salary;
        
        _employeeCount++;
    }
    
    public string Organization
    {
        get => _organization;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Organization cannot be null or empty.");
            _organization = value;
        }
    }

    public string Position
    {
        get => _position;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Position cannot be null or empty.");
            _position = value;
        }
    }

    public double Experience
    {
        get => _experience;
        set
        {
            if (value < 0)
                throw new ArgumentException("Experience cannot be negative.");
            _experience = value;
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Name cannot be null or empty.");
            _name = value;
        }
    }

    public char Gender
    {
        get => _gender;
        set
        {
            value = char.ToUpperInvariant(value);
            if (value != 'M' && value != 'F')
                throw new ArgumentException("Gender must be either 'M' or 'F'.");
            _gender = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Age must be a positive number.");
            _age = value;
        }
    }

    public double Salary
    {
        get => _salary;
        set => _salary = value;
    }

    public void AddSalary(double additionalSalary)
    {
        Salary += additionalSalary;
    }

    public static bool operator ==(Employee e1, Employee e2) => e1._name == e2._name;

    public static bool operator !=(Employee e1, Employee e2) => e1._name != e2._name;
    
    public void Dispose() => _employeeCount--;
    
    public override string ToString()
    {
        return $"Name: {Name}\nAge: {Age}\nGender: {Gender}\nOrganization: {Organization}\nPosition: {Position}\nExperience: {Experience}\nSalary: {Salary}";
    }
}