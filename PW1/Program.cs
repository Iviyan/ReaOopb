using PW1;
using static Utils.Utils;

const Tasks task = Tasks.T2;

if (task == Tasks.T1)
{
    double length = ReadValue<double>("Enter rectangle length: ");
    double width = ReadValue<double>("Enter rectangle width: ");

    Rectangle rectangle = new(length, width);

    Console.WriteLine($"Rectangle {rectangle.Length} X {rectangle.Width}, area = {rectangle.Area}.");
}

if (task == Tasks.T1A)
{
    int count = ReadValue<int>("Enter the number of rectangles: ", 
        c => c is > 10 or <= 0 ? "The number must be <= 10 and > 0" : null);

    List<Rectangle> rectangles = new(count);

    for (int i = 0; i < count; i++)
    {
        Console.WriteLine($"---{i + 1}---");
        
        double length = ReadValue<double>("Enter rectangle length: ");
        double width = ReadValue<double>("Enter rectangle width: ");

        Rectangle rectangle = new(length, width);
        rectangles.Add(rectangle);
    }
    
    Console.WriteLine("\nList:");
    foreach (var rectangle in rectangles)
    {
        Console.WriteLine($"Rectangle {rectangle.Length} X {rectangle.Width}, area = {rectangle.Area}.");
    }
}

if (task == Tasks.T2)
{
    int groupSize = ReadValue<int>("Enter the number of students in the group: ");

    List<Student> students = new(groupSize);
    
    for (int i = 0; i < groupSize; i++)
    {
        Console.WriteLine($"Student {i + 1}:");

        while (true)
        {
            try
            {
                string name = ReadValue<string>("Enter student name: ");
                int age = ReadValue<int>("Enter student age: ");
                float grade = ReadValue<float>("Enter student grade: ");

                Student student = new(name, age, grade);
                students.Add(student);
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid input. {e.Message}");
            }
        }
        
        Console.WriteLine();
    }

    Console.WriteLine("Students:");
    foreach (var student in students)
    {
        Console.WriteLine(student.ToString());
    }
}

enum Tasks { T1, T1A, T2 }