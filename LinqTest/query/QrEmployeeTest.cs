using System.Xml.Linq;
using LinqForXML.model;
using LinqForXML.query.employee;
using LinqForXML.xml;

namespace LinqTest.query;

public class QrEmployeeTest
{
    [Test]
    public void Employees()
    {
        Employee[] employees =
        {
            new(id: 1, lastName: "last_name", firstName: "first_name", patronymic: "patronymic",
                sex: "sex", birthday: "1990.01.01", salary: 1, position: "position", departmentId: 1)
        };
        IEnumerable<XElement> actual = new QrEmployees(new XmlEmployee(employees)).Fetch();
        IEnumerable<XElement> expected = new[]
        {
            new XElement("employee",
                new XAttribute("id", 1),
                new XElement("personal",
                    new XElement("last_name", "last_name"),
                    new XElement("first_name", "first_name"),
                    new XElement("patronymic", "patronymic"),
                    new XElement("sex", "sex")
                ),
                new XElement("birthday", "1990.01.01"),
                new XElement("salary", 1,
                    new XAttribute("unit", "руб.")),
                new XElement("department",
                    new XAttribute("department_id", 1),
                    new XElement("position", "position")
                )
            )
        };
        Assert.That(expected.ToList()[0].Value, Is.EqualTo(actual.ToList()[0].Value));
    }
    
    [Test]
    public void BirthdayEmployees()
    {
        Employee[] employees =
        {
            new(id: 1, lastName: "last_name", firstName: "first_name", patronymic: "patronymic",
                sex: "sex", birthday: "1990.01.01", salary: 1, position: "position", departmentId: 1),
            new(id: 2, lastName: "last_name", firstName: "first_name", patronymic: "patronymic",
                sex: "sex", birthday: "1999.01.01", salary: 1, position: "position", departmentId: 1)
        };
        IEnumerable<XElement> actual = new QrBirthdayEmployee(new XmlEmployee(employees), "1990.01.01").Fetch();
        IEnumerable<XElement> expected = new[]
        {
            new XElement("employee",
                new XAttribute("id", 1),
                new XElement("personal",
                    new XElement("last_name", "last_name"),
                    new XElement("first_name", "first_name"),
                    new XElement("patronymic", "patronymic"),
                    new XElement("sex", "sex")
                ),
                new XElement("birthday", "1990.01.01"),
                new XElement("salary", 1,
                    new XAttribute("unit", "руб.")),
                new XElement("department",
                    new XAttribute("department_id", 1),
                    new XElement("position", "position")
                )
            )
        };
        Assert.That(expected.ToList()[0].Value, Is.EqualTo(actual.ToList()[0].Value));
    }
    
    [Test]
    public void PositionEmployees()
    {
        Employee[] employees =
        {
            new(id: 1, lastName: "last_name", firstName: "first_name", patronymic: "patronymic",
                sex: "sex", birthday: "1990.01.01", salary: 1, position: "position1", departmentId: 1),
            new(id: 2, lastName: "last_name", firstName: "first_name", patronymic: "patronymic",
                sex: "sex", birthday: "1999.01.01", salary: 1, position: "position2", departmentId: 1)
        };
        IEnumerable<XElement> actual = new QrPositionEmployee(new XmlEmployee(employees), "position2").Fetch();
        IEnumerable<XElement> expected = new[]
        {
            new XElement("employee",
                new XAttribute("id", 1),
                new XElement("personal",
                    new XElement("last_name", "last_name"),
                    new XElement("first_name", "first_name"),
                    new XElement("patronymic", "patronymic"),
                    new XElement("sex", "sex")
                ),
                new XElement("birthday", "1999.01.01"),
                new XElement("salary", 1,
                    new XAttribute("unit", "руб.")),
                new XElement("department",
                    new XAttribute("department_id", 1),
                    new XElement("position", "position2")
                )
            )
        };
        Assert.That(expected.ToList()[0].Value, Is.EqualTo(actual.ToList()[0].Value));
    }
    
    [Test]
    public void SexEmployees()
    {
        Employee[] employees =
        {
            new(id: 1, lastName: "last_name", firstName: "first_name", patronymic: "patronymic",
                sex: "sex1", birthday: "1990.01.01", salary: 1, position: "position", departmentId: 1),
            new(id: 2, lastName: "last_name", firstName: "first_name", patronymic: "patronymic",
                sex: "sex2", birthday: "1999.01.01", salary: 1, position: "position", departmentId: 1)
        };
        IEnumerable<XElement> actual = new QrSexEmployee(new XmlEmployee(employees), "sex2").Fetch();
        IEnumerable<XElement> expected = new[]
        {
            new XElement("employee",
                new XAttribute("id", 1),
                new XElement("personal",
                    new XElement("last_name", "last_name"),
                    new XElement("first_name", "first_name"),
                    new XElement("patronymic", "patronymic"),
                    new XElement("sex", "sex2")
                ),
                new XElement("birthday", "1999.01.01"),
                new XElement("salary", 1,
                    new XAttribute("unit", "руб.")),
                new XElement("department",
                    new XAttribute("department_id", 1),
                    new XElement("position", "position")
                )
            )
        };
        Assert.That(expected.ToList()[0].Value, Is.EqualTo(actual.ToList()[0].Value));
    }
}