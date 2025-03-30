namespace EmployeeApp;

public class Employee: IComparable<Employee>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Experience { get; set; }

    public Employee(string name, int age, int experience)
    {
        Name = name;
        Age = age;
        Experience = experience;
    }

    // Реалізація IComparable – порівняння за віком
    public int CompareTo(Employee? other)
    {
        if (other == null) return 1;
        return Age.CompareTo(other.Age);
    }

    public override string ToString()
    {
        return $"{Name}, Вік: {Age}, Стаж: {Experience} років";
    }
}