using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.xml;

namespace LinqForXML.query
{
    public class QrOrderBy : IQuery
    {
        private readonly IEnumerable<XElement> _xElements;
        private readonly string _orderBy;

        public QrOrderBy(IQuery query, string orderBy)
        {
            _xElements = query.Fetch();
            _orderBy = orderBy;
        }
        
        public QrOrderBy(IXml xml, string orderBy)
        {
            _xElements = xml.Create();
            _orderBy = orderBy;
        }
        
        public QrOrderBy(XDocument document, string descendants, string orderBy)
        {
            _xElements = document.Descendants(descendants);
            _orderBy = orderBy;
        }

        public QrOrderBy(IEnumerable<XElement> elements, string orderBy)
        {
            _xElements = elements;
            _orderBy = orderBy;
        }
        public IEnumerable<XElement> Fetch()
        {
            return _xElements.OrderBy(o => o.Element(_orderBy)?.Value);
        }

        public override string ToString()
        {
            var str = "";
            Fetch().ToList().ForEach(it => str += $"{it}{Environment.NewLine}");
            return str;
        }
    }
}