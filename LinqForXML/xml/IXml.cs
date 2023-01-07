using System.Collections.Generic;
using System.Xml.Linq;

namespace LinqForXML.xml
{
    public interface IXml
    {
        IEnumerable<XElement> Create();
    }
}