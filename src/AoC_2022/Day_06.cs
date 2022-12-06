using MoreLinq;

namespace AoC_2022;

public class Day_06 : BaseDay
{
    private readonly List<string> _input;

    public Day_06()
    {
        _input = ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        var solution = _input;

        return new("");
    }

    public override ValueTask<string> Solve_2()
    {
        var solution = _input;

        return new("");
    }

    private List<string> ParseInput()
    {
        var file = new ParsedFile(InputFilePath);

        return File.ReadAllLines(InputFilePath).ToList();
    }
}

