using PW2;
using static Utils.Utils;

int count = ReadValue<int>("Enter the number of employees: ",
    c => c is < 2 or > 5 ? "The number must be <= 5 and >= 2" : null);

List<Employee> employees = new(count);

for (int i = 0; i < count; i++)
{
    Console.WriteLine($"Employee {i + 1}:");

    while (true)
    {
        try
        {
            string organization = ReadValue<string>("Enter employee organization: ");
            string position = ReadValue<string>("Enter employee position: ");
            double experience = ReadValue<double>("Enter employee experience: ");
            string name = ReadValue<string>("Enter employee name: ");
            char gender = ReadValue<char>("Enter employee gender (M/F): ");
            int age = ReadValue<int>("Enter employee age: ");
            double salary = ReadValue<double>("Enter employee salary: ");

            Employee employee = new(organization, position, experience, name, gender, age, salary);
            employees.Add(employee);
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Invalid input. {e.Message}");
        }
    }

    Console.WriteLine();
    Console.WriteLine($"Employee count: {Employee.EmployeeCount}\n");
}

Console.WriteLine("Employees:");
foreach (var employee in employees)
{
    Console.WriteLine(employee.ToString());
    employee.Dispose();
    Console.WriteLine($"\nEmployee count: {Employee.EmployeeCount}\n");
}