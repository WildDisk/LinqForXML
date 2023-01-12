using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.query;

namespace LinqForXML.format_answer
{
    public class FAEmployee
    {
        private readonly IEnumerable<XElement> _xElements;
        private readonly string _comment;

        public FAEmployee(IQuery query, string comment)
        {
            _xElements = query.Fetch();
            _comment = comment;
        }

        public FAEmployee(IEnumerable<XElement> elements, string comment)
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
                    str += "- " +
                           $"{it.Element("personal")?.Element("last_name")?.Value} " +
                           $"{it.Element("personal")?.Element("first_name")?.Value} " +
                           $"{it.Element("personal")?.Element("patronymic")?.Value} " +
                           $"{it.Element("personal")?.Element("sex")?.Value} " +
                           $"{it.Element("birthday")?.Value} " +
                           $"{it.Element("salary")?.Value} " +
                           $"{it.Element("salary")?.Attribute("unit")?.Value} " +
                           $"{it.Element("department")?.Element("position")?.Value} " +
                           $"{Environment.NewLine}";
                });
            return str;
        }
    }
}