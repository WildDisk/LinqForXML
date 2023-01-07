using System;
using LinqForXML.model;

namespace LinqForXML.data
{
    public class EmployeeData
    {
        public Employee[] Employees()
        {
            Employee[] employees =
            {
                new Employee.Builder()
                    .EmployeeId(35)
                    .LastName("Иванов")
                    .FirstName("Иван")
                    .Patronymic("Иванович")
                    .Sex("Муж.")
                    .Birthday(new DateTime(1986, 01, 22))
                    .Salary(35000)
                    .Position("Начальник отдела")
                    .DepartmentId(9)
                    .Build(),
                new Employee.Builder()
                    .EmployeeId(41)
                    .LastName("Петров")
                    .FirstName("Петр")
                    .Patronymic("Петрович")
                    .Sex("Муж.")
                    .Birthday(new DateTime(1981, 11, 11))
                    .Salary(30000)
                    .Position("Ведущий специалист")
                    .DepartmentId(9)
                    .Build(),
                new Employee.Builder()
                    .EmployeeId(12)
                    .LastName("Александрова")
                    .FirstName("Александра")
                    .Patronymic("Александровна")
                    .Sex("Жен.")
                    .Birthday(new DateTime(1954, 06,15))
                    .Salary(28000)
                    .Position("Бухгалтер сбыта")
                    .DepartmentId(5)
                    .Build()
            };
            return employees;
        }
    }
}