using MoreLinq;

namespace AoC_2022;

public class Day_02 : BaseDay
{
    private readonly List<string> _input;

    public Day_02()
    {
        _input = ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        var solution = _input.Select(s => s.Split(" "))
            .Scan(new { totalScore = 0 }, (score, hands) => new { totalScore = score.totalScore + ResultOfGame(hands, 1) })
            .Last().totalScore
            .ToString();

        return new(solution);
    }

    public override ValueTask<string> Solve_2()
    {
        var solution = _input.Select(s => s.Split(" "))
            .Scan(new { totalScore = 0 }, (score, hands) => new { totalScore = score.totalScore + ResultOfGame(hands, 2) })
            .Last().totalScore
            .ToString();

        return new(solution);
    }

    private List<string> ParseInput()
    {
        var file = new ParsedFile(InputFilePath);

        return File.ReadAllLines(InputFilePath).ToList();
    }

    private static int ResultOfGame(string[] hands, int part)
    {
        switch (part)
        {
            case 1:
                return hands[1] switch
                {
                    "X" => hands[0] == "A" ? 1 + 3 :
                           hands[0] == "B" ? 1 + 0 :
                                             1 + 6,
                    "Y" => hands[0] == "A" ? 2 + 6 :
                           hands[0] == "B" ? 2 + 3 :
                                             2 + 0,
                    "Z" => hands[0] == "A" ? 3 + 0 :
                           hands[0] == "B" ? 3 + 6 :
                                             3 + 3,
                    _ => throw new Exception("Unknown hand")
                };
            case 2:
                return hands[0] switch
                {
                    "A" => hands[1] == "X" ? 3 + 0 :
                           hands[1] == "Y" ? 1 + 3 :
                                             2 + 6,
                    "B" => hands[1] == "X" ? 1 + 0 :
                           hands[1] == "Y" ? 2 + 3 :
                                             3 + 6,
                    "C" => hands[1] == "X" ? 2 + 0 :
                           hands[1] == "Y" ? 3 + 3 :
                                             1 + 6,
                    _ => throw new Exception("Unknown hand")
                };
            default:
                throw new Exception("Unknown part(!)");
        }
    }
}

