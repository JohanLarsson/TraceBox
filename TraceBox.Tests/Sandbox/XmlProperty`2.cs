using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;

namespace TraceBox.Tests.Sandbox
{
    public class XmlProperty<TSource, TProperty> : XmlProperty
    {
        private readonly PropertyInfo _propertyInfo;
        private readonly Func<TProperty, string> _toString;
        private readonly Func<string, TProperty> _fromString;

        public XmlProperty(Expression<Func<TSource, TProperty>> property,
            Func<TProperty, string> toString,
            Func<string, TProperty> fromString)
        {
            _fromString = fromString;
            _toString = toString;
            var body = (MemberExpression)property.Body;
            _propertyInfo = (PropertyInfo)body.Member;
        }

        public override void Read(object source, XmlReader reader)
        {
            var text = reader.ReadElementString(_propertyInfo.Name);
            var value = _fromString(text);
            _propertyInfo.SetValue(source, value);
        }

        public override void Write(object source, XmlWriter writer)
        {
            var value = (TProperty)_propertyInfo.GetValue(source);
            writer.WriteElementString(_propertyInfo.Name, _toString(value));
        }
    }
}
