using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;

namespace TraceBox.Tests.Sandbox
{
    public abstract class XmlProperty
    {
        public abstract void Read(object source, XmlReader reader);

        public abstract void Write(object source, XmlWriter writer);
    }
}
