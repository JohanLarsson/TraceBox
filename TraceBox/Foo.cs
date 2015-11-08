using System;
using System.Diagnostics;

namespace TraceBox
{
    public class Foo
    {
        public static void TracedMethod()
        {
            Tracer.LogInfo("Start");
            Tracer.LogInfo("End");
        }

        public static void ExceptionMethod()
        {
            Tracer.LogInfo("Start");
            throw new InvalidOperationException("fuu");
        }
    }
}
