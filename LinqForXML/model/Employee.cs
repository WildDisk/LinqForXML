using System;

namespace LinqForXML.model
{
    public class Employee
    {
        public long EmployeeId { get; }
        public string LastName { get; }
        public string FirstName { get; }
        public string Patronymic { get; }
        public string Sex { get; }
        public string Birthday { get; }
        public double Salary { get; }
        public string Position { get; }
        public long DepartmentId { get; }

        public Employee(long id, string lastName, string firstName, string patronymic, string sex, string birthday,
            double salary, string position, long departmentId)
        {
            EmployeeId = id;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Sex = sex;
            Birthday = birthday;
            Salary = salary;
            Position = position;
            DepartmentId = departmentId;
        }

        public class Builder
        {
            private long _employeeId;
            private string _lastName;
            private string _firstName;
            private string _patronymic;
            private string _sex;
            private string _birthday;
            private double _salary;
            private string _position;
            private long _departmentId;
            public Builder EmployeeId(long employeeId)
            {
                _employeeId = employeeId;
                return this;
            }
            public Builder LastName(string lastName)
            {
                _lastName = lastName;
                return this;
            }
            public Builder FirstName(string firstName)
            {
                _firstName = firstName;
                return this;
            }
            public Builder Patronymic(string patronymic)
            {
                _patronymic = patronymic;
                return this;
            }
            public Builder Sex(string sex)
            {
                _sex = sex;
                return this;
            }
            public Builder Birthday(DateTime birthday)
            {
                _birthday = birthday.ToString("yyyy.MM.dd");
                return this;
            }
            public Builder Salary(double salary)
            {
                _salary = salary;
                return this;
            }
            public Builder Position(string position)
            {
                _position = position;
                return this;
            }
            public Builder DepartmentId(long departmentId)
            {
                _departmentId = departmentId;
                return this;
            }
            public Employee Build()
            {
                return new Employee(
                    id: _employeeId,
                    lastName: _lastName,
                    firstName: _firstName,
                    patronymic: _patronymic,
                    sex: _sex,
                    birthday: _birthday,
                    salary: _salary,
                    position: _position,
                    departmentId: _departmentId
                );
            }
        }

        public override string ToString()
        {
            return string.Format(
                $"Id сотрудника: {EmployeeId}\n" +
                $"Фамилия: {LastName}\n" +
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