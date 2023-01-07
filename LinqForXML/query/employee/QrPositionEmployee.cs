using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqForXML.query.employee
{
    public class QrPositionEmployee : IQuery
    {
        private readonly IEnumerable<XElement> _xdEmployees;
        private readonly string _position;

        public QrPositionEmployee(IQuery query, string position)
        {
            _xdEmployees = query.Fetch();
            _position = position;
        }
        public QrPositionEmployee(XDocument document, string position)
        {
            _xdEmployees = document.Descendants("employee");
            _position = position;
        }
        public IEnumerable<XElement> Fetch()
        {
            return _xdEmployees
                .Where(it => it.Element("department")?.Element("position")?.Value == _position);
        }

        public override string ToString()
        {
            var str = "";
            Fetch().ToList().ForEach(it => str += $"{it}{Environment.NewLine}");
            return str;
        }
    }
}