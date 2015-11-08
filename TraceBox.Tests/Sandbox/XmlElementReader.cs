using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;
using TraceBox.Tests.Sandbox;

namespace TraceBox.Tests
{
    public class XmlElementReader : IDisposable
    {
        private readonly object _source;
        private readonly XmlReader _reader;
        private readonly bool _isEmptyElement;

        private XmlElementReader(IXmlElementSerializable source, XmlReader reader)
        {
            _source = source;
            _reader = reader;
            _isEmptyElement = _reader.IsEmptyElement;
            _reader.ReadStartElement();
        }

        public static void ReadXml(IXmlElementSerializable target, XmlReader reader)
        {
            using (var xmlReader = new XmlElementReader(target, reader))
            {
                foreach (var xmlProperty in target.Properties)
                {
                    xmlReader.Read(xmlProperty);
                }
            }
        }

        private void Read(XmlProperty xmlProperty)
        {
            xmlProperty.Read(_source, _reader);
        }

        public void Dispose()
        {
            if (!_isEmptyElement)
            {
                _reader.ReadEndElement();
            }
        }
    }
}