namespace Advent2025.App.Days;

using System.IO;

public static class DebugSink
{
    public static TextWriter? Writer { get; set; }

    public static void Write(string value)
    {
        Writer?.Write(value);
    }

    public static void WriteLine(string value)
    {
        Writer?.WriteLine(value);
    }
}
