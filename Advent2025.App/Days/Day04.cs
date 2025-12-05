using System.Threading.Tasks.Sources;

namespace Advent2025.App.Days;

public sealed class Day04 : IDay
{
    public int Number => 4;

    public string Part1(string input)
    {
        var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int result = 0;
        int rows = lines[0].Length;
        int cols = lines.Length;

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                char c = lines[i][j];
                if (c == '@')
                {
                    result += CanBeLifted(lines, i, j);
                }
            }
        }
        return result.ToString();
    }

    public string Part2(string input)
    {
        var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int result = 0;
        int rows = lines[0].Length;
        int cols = lines.Length;

        char[,] map = new char[cols, rows];
        char[,] newMap = new char[cols, rows];
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                map[i, j] = lines[i][j];
            }
        }

        while (true)
        {
            int curResult = 0;
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    char c = map[i, j];
                    if (c == '@')
                    {
                        if (CanBeLifted2(map, i, j) == 1)
                        {
                            curResult++;
                            newMap[i, j] = '.';
                        }
                        else
                        {
                            newMap[i, j] = c;
                        }
                    }
                    else
                    {
                        newMap[i, j] = c;
                    }
                }
            }
            result += curResult;
            map = newMap;
            if (curResult == 0) break;
        }
        return result.ToString();
    }

    private static int CanBeLifted(string[] lines, int i, int j)
    {
        int count = 0;
        int rows = lines.Length;
        int cols = lines[0].Length;
        for (int di = -1; di <= 1; di++)
        {
            for (int dj = -1; dj <= 1; dj++)
            {
                if (di == 0 && dj == 0) continue;
                int ni = i + di;
                int nj = j + dj;
                if (ni >= 0 && ni < rows && nj >= 0 && nj < cols)
                {
                    if (lines[ni][nj] == '@') count++;
                }
            }
        }
        return count < 4 ? 1 : 0;
    }

        private static int CanBeLifted2(char[,] map, int i, int j)
    {
        int count = 0;
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);
        for (int di = -1; di <= 1; di++)
        {
            for (int dj = -1; dj <= 1; dj++)
            {
                if (di == 0 && dj == 0) continue;
                int ni = i + di;
                int nj = j + dj;
                if (ni >= 0 && ni < rows && nj >= 0 && nj < cols)
                {
                    if (map[ni,nj] == '@') count++;
                }
            }
        }
        return count < 4 ? 1 : 0;
    }
}
