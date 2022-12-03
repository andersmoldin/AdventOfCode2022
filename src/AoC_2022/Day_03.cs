using MoreLinq;

namespace AoC_2022;

public class Day_03 : BaseDay
{
    private readonly List<string> _input;

    public Day_03()
    {
        _input = ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        var solution = _input.Select(s => s.Chunk(s.Length / 2).First().Intersect(s.Chunk(s.Length / 2).Last()).Single())
                             .Select(s => Char.IsUpper(s) ? (int)s - 38 : (int)s - 96)
                             .Sum()
                             .ToString();

        return new(solution);
    }

    public override ValueTask<string> Solve_2()
    {
        var solution = _input.Chunk(3)
                             .Select(a => a[0].Intersect(a[1].Intersect(a[2])).Single())
                             .Select(s => Char.IsUpper(s) ? (int)s - 38 : (int)s - 96)
                             .Sum()
                             .ToString();

        return new(solution);
    }

    private List<string> ParseInput()
    {
        var file = new ParsedFile(InputFilePath);

        return File.ReadAllLines(InputFilePath).ToList();
    }
}

