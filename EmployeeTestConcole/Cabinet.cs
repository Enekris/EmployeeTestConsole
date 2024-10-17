namespace EmployeeTestConsole
{
    public class Cabinet
    {
        public readonly Employee[] Employees;
        public readonly string Number;
        public Cabinet(string number, params Employee[] employees)
        {
            Employees = employees;
            Number = number;
        }
    }
}
