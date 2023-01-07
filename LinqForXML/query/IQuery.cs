using System.Collections.Generic;
using System.Xml.Linq;

namespace LinqForXML.query
{
    public interface IQuery
    {
        IEnumerable<XElement> Fetch();
    }
}