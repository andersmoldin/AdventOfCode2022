using MoreLinq;

namespace AoC_2022;

public class Day_04 : BaseDay
{
    private readonly IEnumerable<((int Start, int End) FirstElf, (int Start, int End) SecondElf)> _input;

    public Day_04()
    {
        _input = ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        var solution = _input
            .Count(e => (e.FirstElf.End >= e.SecondElf.Start && e.FirstElf.End <= e.SecondElf.End) ||
                     e.SecondElf.Start >= e.FirstElf.Start && e.SecondElf.End <= e.FirstElf.End)
            .ToString();

        return new(solution);
    }

    public override ValueTask<string> Solve_2()
    {
        var solution = _input
            .Count(e => Math.Max(0, Math.Min(e.FirstElf.End, e.SecondElf.End) - Math.Max(e.FirstElf.Start, e.SecondElf.Start) + 1) > 0)
            .ToString();

        return new(solution);
    }

    private IEnumerable<((int Start, int End) FirstElf, (int Start, int End) SecondElf)> ParseInput()
    {
        var file = new ParsedFile(InputFilePath);

        return File.ReadAllLines(InputFilePath)
            .Select(l =>
            {
                var pair = l.Split(",");
                var first = pair[0].Split("-").Select(Int32.Parse);
                var second = pair[1].Split("-").Select(Int32.Parse);
                var firstStart = first.First();
                var firstEnd = first.Last();
                var secondStart = second.First();
                var secondEnd = second.Last();

                return (FirstElf: (Start: firstStart, End: firstEnd),
                        SecondElf: (Start: secondStart, End: secondEnd));
            });
    }
}