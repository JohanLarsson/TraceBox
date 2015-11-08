using System.IO;
using System.Text;
using System.Xml.Serialization;
using Xunit;

namespace TraceBox.Tests
{
    public class XmlTests
    {
        [Fact]
        public void RoundtripXml()
        {
            var dummy = new Dummy { Value1 = 1, Value2 = 2 };
            var stringBuilder = new StringBuilder();
            var serializer = new XmlSerializer(dummy.GetType());
            using (var writer = new StringWriter(stringBuilder))
            {
                serializer.Serialize(writer, dummy);
            }

            var xml = stringBuilder.ToString();
            using (var reader = new StringReader(xml))
            {
                var roundtrip = (Dummy)serializer.Deserialize(reader);
                Assert.Equal(dummy.Value1, roundtrip.Value1);
                Assert.Equal(dummy.Value2, roundtrip.Value2);
            }
        }
    }
}