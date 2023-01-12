using System.Xml.Linq;
using LinqForXML.format_answer;
using LinqForXML.model;
using LinqForXML.query.product;
using LinqForXML.xml;

namespace LinqTest.format_answer;

public class FaProductTest
{
    [Test]
    public void CheckAnswer()
    {
        Product[] products =
        {
            new(id:1, name:"name", manufacturer:"manufacturer", numberInStock:1, weight:1, price:1, storeId:"01")
        };
        string actual = new FaProduct(new QrProducts(new XmlProduct(products)), "test").ToString();
        var expected = $"***** test *****{Environment.NewLine}- 1 1 name manufacturer 1г. 1руб. {Environment.NewLine}";
        Assert.That(expected, Is.EqualTo(actual));
    }
}