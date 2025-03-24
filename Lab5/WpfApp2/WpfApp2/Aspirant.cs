namespace WpfApp2;

public class Aspirant:Student
{
    public string Supervisor { get; set; }

    public Aspirant(string name, int course, int grade, string supervisor)
        : base(name, course, grade)
    {
        Supervisor = supervisor;
    }

    public override void NextCourse()
    {
        if (Grade >= 4)
        {
            Course++;
        }
    }

    public override int Scholarship()
    {
        return 5000;
    }

    public override string GetInfo()
    {
        return $"{base.GetInfo()}\nКерівник роботи: {Supervisor}";
    }
}