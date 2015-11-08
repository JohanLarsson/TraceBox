using System.Collections.Generic;
using TraceBox.Tests.Sandbox;

namespace TraceBox.Tests
{
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    public class Dummy : IXmlElementSerializable
    {
        public Dummy()
        {
        }

        public int Value1 { get; set; }

        public int Value2 { get; set; }

        #region IXmlSerializable

        private static readonly IReadOnlyList<XmlProperty> Properties = XmlProperties.For<Dummy>()
            .Add(x => x.Value1)
            .Add(x => x.Value2);

        IReadOnlyList<XmlProperty> IXmlElementSerializable.Properties => Properties;

        XmlSchema IXmlSerializable.GetSchema() => null;

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            XmlElementReader.ReadXml(this, reader);
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            XmlElementWriter.WriteXml(this, writer);
        }
        #endregion
    }
}