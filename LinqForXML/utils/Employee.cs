using System;

namespace LinqForXML.utils
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string LatName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Sex { get; set; }
        public string Birthday { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public long DepartmentId { get; set; }

        public override string ToString()
        {
            return string.Format(
                $"Id сотрудника: {EmployeeId}\n" +
                $"Фамилия: {LatName}\n" +
                $"Имя: {FirstName}\n" +
                $"Отчество: {Patronymic}\n" +
                $"Пол: {Sex}\n" +
                $"День рождения: {Birthday}\n" +
                $"Оклад: {Salary}\n" +
                $"Должность: {Position}\n" +
                $"Id отдела: {DepartmentId}"
            );
        }
    }
}