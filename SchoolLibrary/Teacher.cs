namespace SchoolLibrary
{
    public class Teacher : Person
    {
        public int Salary { get; set; }

        public void ValidateSalary()
        {
            if (Salary < 0)
            {
                throw new ArgumentOutOfRangeException($"Salary must be positive: {Salary}");
            }
        }
        public override string ToString()
        {
            return $"{Id}, {Name}, {Salary}";
        }

        public void Validate()
        {
            ValidateName();
            ValidateSalary();
        }
    }
}
