using System.Diagnostics;

namespace TraceBox
{
    public class Foo
    {
        public static void TracedMethod()
        {
            Trace.WriteLine("Start", "Info");
            Trace.WriteLine("End", "Info");
        }
    }
}
