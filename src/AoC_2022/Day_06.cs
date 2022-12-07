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
        return FindMarker(_input.Single(), 4);
    }

    public override ValueTask<string> Solve_2()
    {
        return FindMarker(_input.Single(), 14);
    }

    private ValueTask<string> FindMarker(string input, int markerLength)
    {
        foreach (var (c, i) in input.Select((c, i) => (c, i)))
        {
            if (i > markerLength - 2)
            {
                if (input.Substring(i - (markerLength - 1), markerLength).Distinct().Count() == input.Substring(i - (markerLength - 1), markerLength).Length)
                {
                    return new((i + 1).ToString());
                }
            }
        }

        throw new Exception("No signal found.");
    }

    private List<string> ParseInput()
    {
        var file = new ParsedFile(InputFilePath);

        return File.ReadAllLines(InputFilePath).ToList();
    }
}

