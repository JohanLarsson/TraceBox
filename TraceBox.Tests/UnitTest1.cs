namespace TraceBox.Tests
{
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void CallTracedMethod()
        {
            Foo.TracedMethod();
        }
    }
}
