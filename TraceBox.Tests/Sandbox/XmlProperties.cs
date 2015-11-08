namespace TraceBox.Tests.Sandbox
{
    public static class XmlProperties
    {
        public static XmlProperties<TSource> For<TSource>()
        {
            return new XmlProperties<TSource>();
        }
    }
}