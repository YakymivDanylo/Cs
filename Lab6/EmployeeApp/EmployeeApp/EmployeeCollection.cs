using System.Collections;

namespace EmployeeApp;

public class EmployeeCollection: IEnumerable<Employee>
{
    private List<Employee> employees = new List<Employee>();

    public void Add(Employee employee)
    {
        employees.Add(employee);
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        return employees.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}