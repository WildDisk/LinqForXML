using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinqForXML.xml;

namespace LinqForXML.query.employee
{
    public class QrBirthdayEmployee : IQuery
    {
        private readonly IEnumerable<XElement> _xdEmployees;
        private readonly string _birthday;

        public QrBirthdayEmployee(IQuery query, DateTime birthday)
        {
            _xdEmployees = query.Fetch();
            _birthday = birthday.ToString("yyyy.MM.dd");
        }
        public QrBirthdayEmployee(IQuery query, string birthday)
        {
            _xdEmployees = query.Fetch();
            _birthday = birthday;
        }
        public QrBirthdayEmployee(IXml xml, DateTime birthday)
        {
            _xdEmployees = xml.Create();
            _birthday = birthday.ToString("yyyy.MM.dd");
        }
        
        public QrBirthdayEmployee(IXml xml, string birthday)
        {
            _xdEmployees = xml.Create();
            _birthday = birthday;
        }

        public QrBirthdayEmployee(XDocument document, string birthday)
        {
            _xdEmployees = document.Descendants("employee");
            _birthday = birthday;
        }

        public QrBirthdayEmployee(IEnumerable<XElement> elements, string birthday)
        {
            _xdEmployees = elements;
            _birthday = birthday;
        }

        public IEnumerable<XElement> Fetch()
        {
            return _xdEmployees.Where(e => e.Element("birthday")?.Value == _birthday);
        }

        public override string ToString()
        {
            var str = "";
            Fetch().ToList().ForEach(it => str += $"{it}{Environment.NewLine}");
            return str;
        }
    }
}