using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;

namespace ConsoleApp1.Commands;

public class BattleshipsGameCommand : Command
{
    private ApplicationState state;

    private const int GridSize = 9;
    Random rand = new Random();
    List<Ship> ships = new List<Ship>();
    List<Ship> computerShips = new List<Ship>();

    public BattleshipsGameCommand(ApplicationState state, Guid parentId) : base(0, parentId)
    {
        this.state = state;
        ships.Add(new Ship
        {
            Size = 2,
            IsSunk = false,
            Segments = [
            new Segment{IsHit= false, X = 2, Y = 2},
            new Segment{IsHit= true, X = 3, Y = 2}
            ]
        });
        computerShips.Add(new Ship
        {
            Size = 2,
            IsSunk = false,
            Segments = [
            new Segment{IsHit= false, X = 2, Y = 2},
            new Segment{IsHit= true, X = 3, Y = 2},
            new Segment{IsHit= false, X = 4, Y = 2},
            new Segment{IsHit= true, X = 5, Y = 2}
            ]
        });

    }

    public override string Name => "battleships";

    protected override void RunCommand(Queue<string> commandQueue)
    {
        Console.Clear();
        Console.WriteLine("Welcome to Battheships yo!");

        while (true)
        {
            PrintGrids();
            var attack = GetAttack();

        }

        Console.WriteLine("pick positions to place your 3 ships:");
        //talk about dependency injection

    }

    private Attack GetAttack()
    {
        do
        {
            var line = Console.ReadLine();
            if (line == null)
            {
                continue;
            }
            if (line.Length != 2)
            {
                continue ;
            }
            
            int row = (line[0] - GridSize);

            if (row >= GridSize)
            {
                continue;
            }

            if (!char.IsNumber(line[1]) && !int.TryParse(line[1].ToString(), out _))
            {
                continue;
            }
            return new Attack
            {
                X = row,
                Y = int.Parse(line[1].ToString())
            };

        }
        while (true);

    }

    private string GetMapCharacter(int x, int y, bool isPlayerGrid)
    {
        if (isPlayerGrid)
        {
            var segment = ships
                 .SelectMany(x => x.Segments)
                 .Where(s => s.X == x && s.Y == y)
                 .FirstOrDefault();

            if (segment == null)
            {
                return "⋅";
            }

            if (segment.IsHit)
            {
                return "X";
            }
            return "O";

        }
        else
        {
            var segment = computerShips
                .SelectMany(x => x.Segments)
                .Where(s => s.X == x && s.Y == y && s.IsHit)
                .FirstOrDefault();
            if (segment == null)
            {
                return "⋅";
            }
            return "X";
        }
    }

    private void PrintGrids()
    {
        string numbers = string.Join(" ", Enumerable.Range(1, GridSize));

        Console.WriteLine($"  {numbers}      {numbers}");  // Column headers

        for (int x = 0; x < GridSize; x++)
        {
            char row = (char)('A' + x);
            Console.Write(row + " ");  // Row label

            for (int y = 0; y < GridSize; y++)
            {
                Console.Write($"{GetMapCharacter(x, y, true)} ");
            }

            Console.Write("     ");

            for (int y = 0; y < GridSize; y++)
            {
                Console.Write($"{GetMapCharacter(x, y, false)} ");
            }


            Console.WriteLine();
        }
    }
}
public class Ship
{
    public int Size { get; set; }
    public bool IsSunk { get; set; }

    public Segment[] Segments { get; set; } = [];
}

public class Segment
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsHit { get; set; }
}

public class Attack
{
    public int X { get; set; }
    public int Y { get; set; }
}