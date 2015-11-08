using System.Diagnostics;

namespace TraceBox
{
    public static class Tracer
    {
        public static readonly string Name = typeof(Tracer).Assembly.GetName().FullName;

        private static TraceSource Info = new TraceSource(Name, SourceLevels.Information);

        public static void LogInfo(string message)
        {
            Info.TraceInformation(message);
        }
    }
}
