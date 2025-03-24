namespace WpfApp2;

public class Student
{
    public string Name { get; set; }
    public int Course { get; set; }
    public int Grade { get; set; }

    public Student(string name, int course, int grade)
    {
        Name = name;
        Course = course;
        Grade = grade;
    }

    public virtual void NextCourse()
    {
        if (Grade >= 3)
        {
            Course++;
        }
    }

    public virtual int Scholarship()
    {
        if (Grade == 5)
        {
            return 3000;
        }
        else if (Grade == 4)
        {
            return 2000;
        }
        else
        {
            return 0;
        }
    }

    public virtual string GetInfo()
    {
        return $"ПІБ: {Name}\nКурс: {Course}\nМінімальна оцінка: {Grade}\nСтипендія: {Scholarship()} грн";
    }
}

