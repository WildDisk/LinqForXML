using System.Collections.Generic;
using System.Xml.Linq;
using LinqForXML.query;

namespace LinqForXML.xml.xdoc;

public class XmlXDocument
{
    private readonly IEnumerable<XElement> _xElements;
    private readonly string _filName;
    private readonly string _elementsName;

    public XmlXDocument(IQuery query, string filName, string elementsName)
    {
        _xElements = query.Fetch();
        _filName = filName;
        _elementsName = elementsName;
    }

    public XmlXDocument(IXml xml, string filName, string elementsName)
    {
        _xElements = xml.Create();
        _filName = filName;
        _elementsName = elementsName;
    }

    public XmlXDocument(IEnumerable<XElement> xElements, string filName, string elementsName)
    {
        _xElements = xElements;
        _filName = filName;
        _elementsName = elementsName;
    }

    public XDocument Create()
    {
        XDocument xDocument = new XDocument();
        xDocument.Add(new XElement(_elementsName, _xElements));
        xDocument.Save(_filName);
        return XDocument.Load(_filName);
    }
}