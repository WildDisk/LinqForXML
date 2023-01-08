using System.Linq;
using System.Xml.Linq;
using LinqForXML.model;

namespace LinqForXML.xml.old
{
    public class XmlCreateDepartments
    {
        private readonly Employee[] _employees;
        private readonly Department[] _departments;

        internal XmlCreateDepartments(Employee[] employees)
        {
            _employees = employees;
        }

        internal XmlCreateDepartments(Department[] departments)
        {
            _departments = departments;
        }

        /// <summary>
        /// Конструктор xml файла по сотрудникам
        /// </summary>
        public void GenerateXml()
        {
            var xmlData = _employees.Select(e =>
                new XElement("employee",
                    new XAttribute("id", $"{e.EmployeeId} "),
                    new XElement("personal",
                        new XElement("last_name", $"{e.LastName} "),
                        new XElement("first_name", $"{e.FirstName} "),
                        new XElement("patronymic", $"{e.Patronymic} "),
                        new XElement("sex", $"{e.Sex} ")
                    ),
                    new XElement("birthday", $"{e.Birthday} "),
                    new XElement("salary", $"{e.Salary} ",
                        new XAttribute("unit", "руб. ")),
                    new XElement("department",
                        new XAttribute("department_id", $"{e.DepartmentId} "),
                        new XElement("position", $"{e.Position} ")
                    )
                )
            );
            XElement rootElement = new XElement("employees", xmlData);
            XDocument xDocument = new XDocument();
            xDocument.Add(rootElement);
            xDocument.Save("employee.xml");
        }

        /// <summary>
        /// Конструктор временного xml для работы с join
        /// </summary>
        public XElement GenerateTmpXml()
        {
            var departments = _departments.Select(d =>
                new XElement("department",
                    new XAttribute("id", d.DepartmentId),
                    new XElement("department_name", d.DepartmentName),
                    new XElement("employee_places", d.EmployeePlaces)
                )
            );
            XElement tmpDoc = new XElement("departments", departments);
            return tmpDoc;
        }
    }
}