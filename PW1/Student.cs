namespace PW1;

public class Student
{
    private int _age;
    private string _name;
    private float _grade;

    public Student(string name, int age, float grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public Student() : this(string.Empty, 0, 0) { }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.", nameof(value));
            _name = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "The age cannot be less than 0.");
            _age = value;
        }
    }

    public float Grade
    {
        get => _grade;
        set
        {
            if (value is < 2 or > 5) 
                throw new ArgumentOutOfRangeException(nameof(value), "The grade cannot be less than 2 or greater than 5.");
            _grade = value;
        }
    }

    public override string ToString() => $"Name: {Name}, Age: {Age}, Grade: {Grade}.";
}