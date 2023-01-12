using System.Xml.Linq;
using LinqForXML.model;
using LinqForXML.query.product;
using LinqForXML.xml;

namespace LinqTest.xml;

public class XmlProductTest
{
    [Test]
    public void CreateXml()
    {
        Product[] products =
        {
            new(id:1, name:"name", manufacturer:"manufacturer", numberInStock:1, weight:1, price:1, storeId:"01")
        };
        IEnumerable<XElement> actual = new XmlProduct(products).Create();
        IEnumerable<XElement> expected = new[]
        {
            new XElement("product",
                new XAttribute("id", 1),
                new XAttribute("numberInStock", 1),
                new XElement("name", "name"),
                new XElement("manufacturer", "manufacturer"),
                new XElement("weight", 1,
                    new XAttribute("unit", "г. ")
                ),
                new XElement("price", 1,
                    new XAttribute("unit", "руб.")
                )
            )
        };
        Assert.That(expected.ToList()[0].Value, Is.EqualTo(actual.ToList()[0].Value));
    }
}