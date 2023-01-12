using System.Xml.Linq;
using LinqForXML.model;
using LinqForXML.query;
using LinqForXML.xml;

namespace LinqTest.query;

public class QrEqualTest
{
    [Test]
    public void EqualElement()
    {
        Department[] departments =
        {
            new(id: 1, departmentName:"department_name", employeePlaces:1)
        };
        IEnumerable<XElement> actual = new QrEqual(
            new XmlDepartment(departments), 
            "department_name", 
            "department_name"
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