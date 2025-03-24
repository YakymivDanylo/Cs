namespace WpfApp2;

public class StudentContract: Student
{
    public bool ContractPaid { get; set; }
    public StudentContract(string name, int course, int grade,bool contractPaid) : base(name, course, grade)
    {
        ContractPaid = contractPaid;
    }
    public new void MoveToNextCourse()
    {
        if (Grade >= 3 && ContractPaid)
            Course++;
    }

    public new decimal GetScholarship()
    {
        return 0; // Контрактник не отримує стипендію
    }
}