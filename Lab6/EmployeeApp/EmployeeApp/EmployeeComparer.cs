namespace EmployeeApp;

public class EmployeeComparer: IComparer<Employee>
{
    public int Compare(Employee? x, Employee? y)
    {
        if (x == null || y == null) return 0;
        return x.Experience.CompareTo(y.Experience);
    }

    public int CompareTo(Employee? other)
    {
        throw new NotImplementedException();
    }
}