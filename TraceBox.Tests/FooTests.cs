namespace TraceBox.Tests
{
    using Xunit;

    public class FooTests
    {
        [Fact]
        public void CallTracedMethod()
        {
            Foo.TracedMethod();
        }
    }
}
