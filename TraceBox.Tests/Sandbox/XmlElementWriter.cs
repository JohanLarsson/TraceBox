using System.Xml;
using TraceBox.Tests.Sandbox;

namespace TraceBox.Tests
{
    public class XmlElementWriter
    {
        private readonly IXmlElementSerializable _source;
        private readonly XmlWriter _writer;

        private XmlElementWriter(IXmlElementSerializable source, XmlWriter writer)
        {
            _source = source;
            _writer = writer;
        }

        public static void WriteXml(IXmlElementSerializable target, XmlWriter writer)
        {
            var elementWriter = new XmlElementWriter(target, writer);
            foreach (var xmlProperty in target.Properties)
            {
                elementWriter.Write(xmlProperty);
            }
        }

        private void Write(XmlProperty xmlProperty)
        {
            xmlProperty.Write(_source, _writer);
        }
    }
}