using Advent2025.App.Days;
using System.Globalization;

var cmdArgs = Environment.GetCommandLineArgs().Skip(1).ToArray();
int day = ParseIntArg(cmdArgs, "--day", 1);
int part = ParseIntArg(cmdArgs, "--part", 1);
string? inputPath = ParseStringArg(cmdArgs, "--input", null);
bool useTestInput = HasSwitch(cmdArgs, "--test");
bool debugMode = HasSwitch(cmdArgs, "--debug");

var days = new Dictionary<int, IDay>
{
    { 1, new Day01() },
    { 2, new Day02() },
    { 3, new Day03() },
    { 4, new Day04() }
};

if (!days.TryGetValue(day, out var solver))
{
    Console.WriteLine($"Day {day} not implemented");
    return;
}

string input = inputPath != null ? File.ReadAllText(Path.GetFullPath(inputPath)) : ReadDefaultInput(day, useTestInput);

System.IO.TextWriter? dbgWriter = null;
if (debugMode)
{
    string outDir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Outputs");
    Directory.CreateDirectory(outDir);
    string outFile = System.IO.Path.Combine(outDir, $"Day{solver.Number:00}_{part}.output");
    dbgWriter = new System.IO.StreamWriter(outFile, false);
    DebugSink.Writer = dbgWriter;
}

string result = part == 1 ? solver.Part1(input) : solver.Part2(input);
Console.WriteLine(result);

if (dbgWriter != null)
{
    dbgWriter.Dispose();
    DebugSink.Writer = null;
}

static int ParseIntArg(string[] args, string key, int defaultValue)
{
    for (int i = 0; i < args.Length - 1; i++)
    {
        if (string.Equals(args[i], key, StringComparison.OrdinalIgnoreCase))
        {
            if (int.TryParse(args[i + 1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var v)) return v;
        }
    }
    return defaultValue;
}

static string? ParseStringArg(string[] args, string key, string? defaultValue)
{
    for (int i = 0; i < args.Length - 1; i++)
    {
        if (string.Equals(args[i], key, StringComparison.OrdinalIgnoreCase)) return args[i + 1];
    }
    return defaultValue;
}

static bool HasSwitch(string[] args, string key)
{
    for (int i = 0; i < args.Length; i++)
    {
        if (string.Equals(args[i], key, StringComparison.OrdinalIgnoreCase)) return true;
    }
    return false;
}

static string ReadDefaultInput(int day, bool test)
{
    string fileName = test ? $"Day{day:00}.test.txt" : $"Day{day:00}.txt";
    string path1 = Path.Combine(Directory.GetCurrentDirectory(), "Inputs", fileName);
    if (File.Exists(path1)) return File.ReadAllText(path1);
    string path2 = Path.Combine(AppContext.BaseDirectory, "Inputs", fileName);
    if (File.Exists(path2)) return File.ReadAllText(path2);
    throw new FileNotFoundException(fileName);
}
