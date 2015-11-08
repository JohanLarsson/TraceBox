using System.Collections.Generic;
using System.Xml.Serialization;
using TraceBox.Tests.Sandbox;

namespace TraceBox.Tests
{
    public interface IXmlElementSerializable : IXmlSerializable
    {
        IReadOnlyList<XmlProperty> Properties { get; }
    }
}