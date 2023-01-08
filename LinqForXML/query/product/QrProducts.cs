using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.xml;

namespace LinqForXML.query.product
{
    public class QrProducts : IQuery
    {
        private readonly IEnumerable<XElement> _xdProducts;

        public QrProducts(IQuery query)
        {
            _xdProducts = query.Fetch();
        }

        public QrProducts(IXml xml)
        {
            _xdProducts = xml.Create();
        }
        
        public QrProducts(XDocument document)
        {
            _xdProducts = document.Descendants("product");
        }

        public QrProducts(IEnumerable<XElement> elements)
        {
            _xdProducts = elements;
        }

        public IEnumerable<XElement> Fetch()
        {
            return _xdProducts;
        }

        public override string ToString()
        {
            var str = "";
            Fetch().ToList().ForEach(it => str += $"{it}{Environment.NewLine}");
            return str;
        }
    }
}