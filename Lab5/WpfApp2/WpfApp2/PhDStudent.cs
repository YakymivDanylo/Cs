namespace WpfApp2;

public class PhDStudent: Student
{
    public string Supervisor{ get; set; }
    public PhDStudent(string name, int course, int grade, string supervisor) : base(name, course, grade)
    {
        Supervisor = supervisor;
    }

    public new void MoveToNextCourse()
    {
        if (Grade>=4)
        {
            Course++;
        }
    }

    public new decimal GetScholarship()
    {
        return 5000;// Аспірант отримує завжди 5000 грн
    }
}