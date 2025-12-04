namespace Advent2025.App.Days;

public interface IDay
{
    int Number { get; }
    string Part1(string input);
    string Part2(string input);
}