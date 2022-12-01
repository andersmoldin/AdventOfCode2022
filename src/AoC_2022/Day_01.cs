using MoreLinq;

namespace AoC_2022;

public class Day_01 : BaseDay
{
    private readonly List<string> _input;

    public Day_01()
    {
        _input = ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        var solution = _input.GroupAdjacent(n => n == string.Empty ? "N" : "Y")
            .Where(g => g.Key == "Y")
            .Max(g => g.Select(int.Parse).Sum())
            .ToString();

        return new(solution);
    }

    public override ValueTask<string> Solve_2()
    {
        var solution = _input.GroupAdjacent(n => n == string.Empty ? "N" : "Y")
            .Where(g => g.Key == "Y")
            .OrderByDescending(g => g.Select(int.Parse).Sum())
            .Take(3)
            .Sum(c => c.Select(int.Parse).Sum())
            .ToString();

        return new(solution);
    }

    private List<string> ParseInput()
    {
        var file = new ParsedFile(InputFilePath);

        return File.ReadAllLines(InputFilePath).ToList();
    }
}

