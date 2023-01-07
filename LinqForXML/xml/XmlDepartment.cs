using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.model;

namespace LinqForXML.xml
{
    public class XmlDepartment : IXml
    {
        private readonly Department[] _departments;

        public XmlDepartment(Department[] departments)
        {
            _departments = departments;
        }

        public IEnumerable<XElement> Create()
        {
            var departments = _departments.Select(d => 
                new XElement("department",
                    new XAttribute("id", d.DepartmentId),
                    new XElement("department_name", d.DepartmentName),
                    new XElement("employee_places", d.EmployeePlaces)
                )
            );
            XDocument xDocument = new XDocument();
            xDocument.Add(new XElement("departments", departments));
            xDocument.Save("department.xml");
            return XDocument.Load("department.xml").Descendants("department");
        }
    }
}