namespace EmployeeTestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            var cab101 = new Cabinet("Кабинет 101", new Employee("Иван", "Иванов"), new Employee("Сергей", "Сергеев"));
            var cab102 = new Cabinet("Кабинет 102", new Employee("Дмитрий", "Дмитриев"), new Employee("Петр", "Петров"));
            var cab103 = new Cabinet("Кабинет 103", new Employee("Алексей", "Алексеев"));

            Dictionary<string, string> cabEmp = new Dictionary<string, string>();

            var empCab = AddToDistr(cab101, cab102, cab103);

            //foreach (var keyValue in empCab)  //проверка словаря
            //{
            //    Console.Write(keyValue.Key + ": ");
            //    foreach (var cab in keyValue.Value)
            //    {
            //        Console.Write(cab);
            //    }
            //    Console.WriteLine();
            //}

            var resultCabEmp = CheckToResult(empCab);
            foreach (var cabEmpKV in resultCabEmp)
            {
                Console.WriteLine($"\"{cabEmpKV.Key}\": [{string.Join(", ", cabEmpKV.Value.Select(e => $"\"{e}\""))}]");
            }    
               
        }

        public static Dictionary<string, string> AddToDistr(params Cabinet[] cabinets)
        {
            Dictionary<string, string> empCab = new Dictionary<string, string>();

            foreach (var cabinet in cabinets)
            {
                //if (cabinet.Employees.Length > 0)  тут было бы удобнее всю логику сделать
                //{
                foreach (var emp in cabinet.Employees)
                    {
                        empCab.Add(emp.Name + " " + emp.Family, cabinet.Number);
                    }
                //}
            }
            return empCab;
        }
        public static Dictionary<string, List<string>> CheckToResult(Dictionary<string, string> empCab)
        {
            var result = empCab
                 .GroupBy(e => e.Value)
                 .Where(g => g.Count() > 1)
                 .ToDictionary(g => g.Key, g => g.Select(e => e.Key).ToList());

            return result;
        }
    }
}
