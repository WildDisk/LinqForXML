using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.xml;

namespace LinqForXML.query
{
    public class QrEqual : IQuery
    {
        private readonly IEnumerable<XElement> _xElements;
        private readonly string _field;
        private readonly string _value;

        public QrEqual(IQuery query, string field, string value)
        {
            _xElements = query.Fetch();
            _field = field;
            _value = value;
        }

        public QrEqual(XDocument document, string descendants, string field, string value)
        {
            _xElements = document.Descendants(descendants);
            _field = field;
            _value = value;
        }
        
        public QrEqual(IXml xml, string field, string value)
        {
            _xElements = xml.Create();
            _field = field;
            _value = value;
        }
        
        public QrEqual(IEnumerable<XElement> elements, string field, string value)
        {
            _xElements = elements;
            _field = field;
            _value = value;
        }
        public IEnumerable<XElement> Fetch()
        {
            return _xElements.Where(it => it.Element(_field)?.Value == _value);
        }
    }
}