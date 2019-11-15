using System;
using LinqForXML.utils;

namespace LinqForXML.datas
{
    public class InitializeDataEmployee
    {
        public Employee[] Employees()
        {
            Employee[] employees =
            {
                new Employee
                {
                    EmployeeId = 35,
                    LatName = "Иванов",
                    FirstName = "Иван",
                    Patronymic = "Иванович",
                    Sex = "Муж.",
                    Birthday = new DateTime(1986, 01, 22).ToString("yyyy.MM.dd"),
                    Salary = 35000.00,
                    //Начальник отдела
                    Position = "Начальник отдела",
                    DepartmentId = 9
                },
                new Employee
                {
                    EmployeeId = 41,
                    LatName = "Петров",
                    FirstName = "Петр",
                    Patronymic = "Петрович",
                    Sex = "Муж.",
                    Birthday = new DateTime(1981, 11, 11).ToString("yyyy.MM.dd"),
                    Salary = 30000.00,
                    //Ведущий специалист
                    Position = "Ведущий специалист",
                    DepartmentId = 9
                },
                new Employee
                {
                    EmployeeId = 12,
                    LatName = "Александрова",
                    FirstName = "Александра",
                    Patronymic = "Александровна",
                    Sex = "Жен.",
                    Birthday = new DateTime(1954, 06,15).ToString("yyyy.MM.dd"),
                    Salary = 28000.00,
                    //Бухгалтер сбыта
                    Position = "Бухгалтер сбыта",
                    DepartmentId = 5
                }
            };
            return employees;
        }
    }
}