using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.xml;

namespace LinqForXML.query.employee
{
    public class QrSexEmployee : IQuery
    {
        private readonly IEnumerable<XElement> _xdEmployees;
        private readonly string _sex;

        public QrSexEmployee(IQuery query, string sex)
        {
            _xdEmployees = query.Fetch();
            _sex = sex;
        }

        public QrSexEmployee(IXml xml, string sex)
        {
            _xdEmployees = xml.Create();
            _sex = sex;
        }

        public QrSexEmployee(XDocument document, string sex)
        {
            _xdEmployees = document.Descendants("employee");
            _sex = sex;
        }

        public QrSexEmployee(IEnumerable<XElement> elements, string sex)
        {
            _xdEmployees = elements;
            _sex = sex;
        }

        public IEnumerable<XElement> Fetch()
        {
            return _xdEmployees.Where(it => it.Element("personal")?.Element("sex")?.Value == _sex);
        }

        public override string ToString()
        {
            var str = "";
            Fetch().ToList().ForEach(it => str += $"{it}{Environment.NewLine}");
            return str;
        }
    }
}