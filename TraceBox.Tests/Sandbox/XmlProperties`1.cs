using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml;

namespace TraceBox.Tests.Sandbox
{
    public class XmlProperties<TSource> : IReadOnlyList<XmlProperty>
    {
        private readonly List<XmlProperty> _properties = new List<XmlProperty>();

        public XmlProperties<TSource> Add<TProperty>(
            Expression<Func<TSource, TProperty>> property,
            Func<TProperty, string> toString,
            Func<string, TProperty> fromString)
        {
            _properties.Add(new XmlProperty<TSource, TProperty>(property, toString, fromString));
            return this;
        }

        public XmlProperties<TSource> Add(Expression<Func<TSource, int>> property)
        {
            return Add(property, XmlConvert.ToString, XmlConvert.ToInt32);
        }

        public int Count => _properties.Count;

        public XmlProperty this[int index] => _properties[index];

        public IEnumerator<XmlProperty> GetEnumerator() => _properties.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}