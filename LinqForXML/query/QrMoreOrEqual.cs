using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.xml;

namespace LinqForXML.query
{
    public class QrMoreOrEqual : IQuery
    {
        private readonly IEnumerable<XElement> _xElements;
        private readonly string _field;
        private readonly double _number;

        public QrMoreOrEqual(IQuery query, string field, double number)
        {
            _xElements = query.Fetch();
            _field = field;
            _number = number;
        }

        public QrMoreOrEqual(XDocument document, string descendants, string field, double number)
        {
            _xElements = document.Descendants(descendants);
            _field = field;
            _number = number;
        }
        
        public QrMoreOrEqual(IXml xml, string field, double number)
        {
            _xElements = xml.Create();
            _field = field;
            _number = number;
        }
        
        public QrMoreOrEqual(IEnumerable<XElement> elements, string field, double number)
        {
            _xElements = elements;
            _field = field;
            _number = number;
        }
        public IEnumerable<XElement> Fetch()
        {
            return _xElements.Where(it => Convert.ToDouble(it.Element(_field)?.Value) >= _number);
        }
    }
}