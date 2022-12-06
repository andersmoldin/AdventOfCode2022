using System.Text.RegularExpressions;
using MoreLinq;

namespace AoC_2022;

public class Day_05 : BaseDay
{
    private readonly List<string> _input;

    public Day_05()
    {
        _input = ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        var crates = GetCrates(_input);

        var moves = GetMoves(_input);
        MoveCrates(crates, moves);

        var solution = new string(crates.Select(c => c[0]).ToArray());

        return new(solution);
    }

    public override ValueTask<string> Solve_2()
    {
        var crates = GetCrates(_input);

        var moves = GetMoves(_input);
        MoveCrates(crates, moves, true);

        var solution = new string(crates.Select(c => c[0]).ToArray());

        return new(solution);
    }

    private static void MoveCrates(List<string> crates, IEnumerable<(int Amount, int From, int To)> moves, bool reverse = false)
    {
        foreach (var move in moves)
        {
            if (!reverse)
            {
                crates[move.To - 1] = new string(crates[move.From - 1].Substring(0, move.Amount).Reverse().ToArray()) + crates[move.To - 1];
            }
            else
            {
                crates[move.To - 1] = crates[move.From - 1].Substring(0, move.Amount) + crates[move.To - 1];
            }
            crates[move.From - 1] = crates[move.From - 1].Substring(move.Amount);
        }
    }

    private List<string> GetCrates(List<string> input)
    {
        return input.TakeUntil(l => l.StartsWith(" 1"))
                                   .Transpose()
                                   .Select(l => string.Concat(l.Where(c => Char.IsLetter(c))))
                                   .Where(l => l != string.Empty)
                                   .ToList();
    }

    private IEnumerable<(int Amount, int From, int To)> GetMoves(List<string> input)
    {
        return input.Split(string.Empty)
                          .Last()
                          .Select(l =>
                          {
                              var line = l.Split(" ");

                              return (Amount: Convert.ToInt32(line[1]),
                                      From: Convert.ToInt32(line[3]),
                                      To: Convert.ToInt32(line[5]));
                          });
    }

    private List<string> ParseInput()
    {
        var file = new ParsedFile(InputFilePath);

        return File.ReadAllLines(InputFilePath).ToList();
    }
}

