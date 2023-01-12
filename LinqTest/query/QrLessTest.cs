using System.Xml.Linq;
using LinqForXML.model;
using LinqForXML.query;
using LinqForXML.xml;

namespace LinqTest.query;

public class QrLessTest
{
    [Test]
    public void Less()
    {
        Department[] departments =
        {
            new(id: 1, departmentName:"department_name", employeePlaces:1),
            new(id: 2, departmentName:"department_name", employeePlaces:2)
        };
        IEnumerable<XElement> actual = new QrLess(
            new XmlDepartment(departments), 
            "id", 
            2
        ).Fetch();
        IEnumerable<XElement> expected = new[]
        {
            new XElement("department",
                new XAttribute("id", 1),
                new XElement("department_name", "department_name"),
                new XElement("employee_places", 1)
            )
        };
        Assert.That(expected.ToList()[0].Value, Is.EqualTo(actual.ToList()[0].Value));
    }
}