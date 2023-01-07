﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.model;

namespace LinqForXML.xml
{
    public class XmlEmployee : IXml
    {
        private readonly Employee[] _employees;
        public XmlEmployee(Employee[] employees)
        {
            _employees = employees;
        }

        public IEnumerable<XElement> Create()
        {
            var xmlData = _employees.Select(e =>
                new XElement("employee",
                    new XAttribute("id", e.EmployeeId),
                    new XElement("personal",
                        new XElement("last_name", e.LastName),
                        new XElement("first_name", e.FirstName),
                        new XElement("patronymic", e.Patronymic),
                        new XElement("sex", e.Sex)
                    ),
                    new XElement("birthday", e.Birthday),
                    new XElement("salary", e.Salary,
                        new XAttribute("unit", "руб.")),
                    new XElement("department",
                        new XAttribute("department_id", e.DepartmentId),
                        new XElement("position", e.Position)
                    )
                )
            );
            XElement rootElement = new XElement("employees", xmlData);
            XDocument xDocument = new XDocument();
            xDocument.Add(rootElement);
            xDocument.Save("employee.xml");
            return XDocument.Load("employee.xml").Descendants("employee");
        }
    }
}