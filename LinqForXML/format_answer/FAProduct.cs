using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.query;
using LinqForXML.xml;

namespace LinqForXML.format_answer
{
    public class FaProduct
    {
        private readonly IEnumerable<XElement> _xElements;
        private readonly string _comment;

        public FaProduct(IQuery query, string comment)
        {
            _xElements = query.Fetch();
            _comment = comment;
        }
        
        public FaProduct(IXml xml, string comment)
        {
            _xElements = xml.Create();
            _comment = comment;
        }

        public FaProduct(XDocument document, string descendants, string comment)
        {
            _xElements = document.Descendants(descendants);
            _comment = comment;
        }
        
        public FaProduct(IEnumerable<XElement> elements, string comment)
        {
            _xElements = elements;
            _comment = comment;
        }

        public override string ToString()
        {
            var str = $"***** {_comment} *****{Environment.NewLine}";
            _xElements
                .ToList()
                .ForEach(it =>
                {
                    str += $"- " +
                           $"{it.Attribute("id")?.Value} " +
                           $"{it.Attribute("numberInStock")?.Value} " +
                           $"{it.Element("name")?.Value} " +
                           $"{it.Element("manufacturer")?.Value} " +
                           $"{it.Element("weight")?.Value}" +
                           $"{it.Element("weight")?.Attribute("unit")?.Value} " +
                           $"{it.Element("price")?.Value}" +
                           $"{it.Element("price")?.Attribute("unit")?.Value} " +
                           $"{Environment.NewLine}";
                });
            return str;
        }
    }
}