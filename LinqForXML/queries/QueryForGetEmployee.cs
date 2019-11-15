using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using LinqForXML.datas;
using LinqForXML.utils;
using LinqForXML.xmlcreates;

namespace LinqForXML.queries
{
    public class QueryForGetEmployee
    {
        private readonly XDocument _employee;

        internal QueryForGetEmployee(XDocument xDocument)
        {
            _employee = xDocument;
        }

        /// <summary>
        /// Парсинг всего xml файла
        /// </summary>
        public void All()
        {
            if (_employee != null)
            {
                var all = _employee
                    .Descendants("employee")
                    .Select(employee => employee.Value);
                foreach (var a in all)
                {
                    Console.WriteLine($"- {a} ");
                }
            }
        }

        /// <summary>
        /// Поиск сотрудников с birthday
        /// </summary>
        /// <param name="birthday">Дата рождения</param>
        public void FindEmployeeWithBirthday(string birthday)
        {
            Console.WriteLine($"\n1. Сотрудники с датой рождения: {birthday}");
            if (_employee != null)
            {
                var employees = _employee
                    .Descendants("employee")
                    .Where(e => e.Element("birthday")?.Value == birthday)
                    .Select(e => e);
                foreach (var e in employees)
                {
                    Console.WriteLine(
                        "- " +
                        $"{e.Element("last_name")?.Value} " +
                        $"{e.Element("first_name")?.Value} " +
                        $"{e.Element("patronymic")?.Value} " +
                        $"{e.Element("birthday")?.Value}"
                    );
                }
            }
        }

        /// <summary>
        /// Количество сотрудников sex пола, занимающих position
        /// </summary>
        /// <param name="sex">Пол</param>
        /// <param name="position">Должность</param>
        public void FindEmployeeWithSexAndPosition(string sex, string position)
        {
            Console.WriteLine($"\n2. Сотрудники {sex} пола, занимающие должность: {position}");
            if (_employee != null)
            {
//                var employees = _employee
//                    .Descendants("employee")
//                    .Where(e => e.Element("sex")?.Value == sex && e.Element("position")?.Value == position)
//                    .Select(e => e);
                var employees = from es in _employee.Descendants("employee")
                    from s in es.Elements("personal")
                    from p in es.Elements("department")
                    where s.Element("sex")?.Value == sex && p.Element("position")?.Value == position
                    select s;
                var countEmployee = employees.Count();
                Console.WriteLine($"- {countEmployee}");
            }
        }

        /// <summary>
        /// Поиск сотрудников с окладом > salary, сгруппировкой по отделам
        /// </summary>
        /// <param name="salary">Сумма оклада</param>
        public void FindEmployeeWithMoreSalary(double salary)
        {
            Console.WriteLine($"\n3. Сотрудники с окладом > {salary}");
            var employees = _employee
                .Descendants("employee")
                .Where(employee => Convert.ToDouble(employee.Element("salary")?.Value) > salary)
                .GroupBy(employee => employee.Element("department")?.Value);
            foreach (var employee in employees)
            {
//                Console.WriteLine($"- {employee.Key}");
                foreach (var element in employee)
                {
                    Console.WriteLine(
                        "- " +
                        $"{element.Element("last_name")?.Value} " +
                        $"{element.Element("first_name")?.Value} " +
                        $"{element.Element("patronymic")?.Value} " +
                        $"{element.Element("salary")?.Value} " +
                        $"{element.Element("department")?.Value}"
                    );
                }
            }
        }

        /// <summary>
        /// Список должностией с указанием отдела
        /// </summary>
        public void ListPositionsWithDepartmentName()
        {
            Department[] departments = new InitializeDataDepartment().Departments();
            XElement departmentXml = new XmlCreateDepartments(departments).GenerateTmpXml();
            Console.WriteLine("\n4. Список должностей с указанием отдела");
            if (_employee != null)
            {
                var employeePlaces = _employee
                    .Descendants("employee")
                    .SelectMany(es =>
                        es.Elements("department"), (es, e) => new {es, e})
                    .Join(departmentXml.Elements("department"),
                        @t => @t.e.Attribute("department_id")?.Value,
                        d => d.Attribute("id")?.Value,
                        (@t, d) => new
                        {
                            position = @t.e.Element("position")?.Value,
                            department = d.Element("department_name")?.Value,
                            employeePlaces = d.Element("employee_places")?.Value
                        });
                Console.WriteLine(
                    $"|{"Должность",25}" +
                    $"|{"Название отдела",40}" +
                    $"|{"Количество мест в отделе",25}|"
                );
                foreach (var employeePlace in employeePlaces)
                {
                    Console.WriteLine(
                        $"|{employeePlace.position,25}" +
                        $"|{employeePlace.department,40}" +
                        $"|{employeePlace.employeePlaces,25}|"
                    );
                }
            }
        }

        /// <summary>
        /// Поиск сотрудников с окладом менее salary
        /// </summary>
        /// <param name="salary">Оклад</param>
        public void FindEmployeeSmallerSalary(double salary)
        {
            Console.WriteLine($"\n5. Сотрудники с окладом < {salary} руб.: ");
            if (_employee != null)
            {
                var employees = _employee.XPathSelectElements($"//employee[salary<{salary}]");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"- {employee.Value}");
                }
            }
        }
    }
}