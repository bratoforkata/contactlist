using ConsoleApp1.Commands.BattleshipModels;
using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;

namespace ConsoleApp1.Commands;

public class BattleshipsGameCommand : Command
{
    private ApplicationState state;

    private const int GridSize = 9;
    Random rand = new Random();
    List<Ship> playerShips = new List<Ship>();
    List<Ship> computerShips = new List<Ship>();
    HashSet<Attack> playerAttacks = new HashSet<Attack>();
    HashSet<Attack> computerAttacks = new HashSet<Attack>();

    public BattleshipsGameCommand(ApplicationState state, Guid parentId) : base(0, parentId)
    {
        this.state = state;
    }

    public override string Name => "battleships";

    protected override void RunCommand(Queue<string> commandQueue)
    {
        Initialize();

        while (true)
        {
            PrintGrids();
            var attack = GetAttack();
            MakeAttack(attack, true);

        }
    }

    private void Initialize()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Battheships yo!");

        var map = MapGenerator.GenerateMap(GridSize);

        playerShips = map.Player1;
        computerShips = map.Player2;

        playerAttacks.Clear();
        computerAttacks.Clear();
    }

    private void MakeAttack(Attack attack, bool isPlayerGrid)
    {
        if (isPlayerGrid)
        {
            if (playerAttacks.Contains(attack))
            {
                Console.WriteLine("you already attacked there!");
                return;
            }
            
            var segment = computerShips
                .SelectMany(s => s.Segments)
                .Where(s=> s.X == attack.X && s.Y == attack.Y)
                .FirstOrDefault();

            if (segment != null) 
            {
                segment.IsHit = true;
                return;
            }

            playerAttacks.Add(attack);
        }
        else
        {
            if (computerAttacks.Contains(attack))
            {
                return;
            }

            var segment = playerShips
                .SelectMany(s => s.Segments)
                .Where(s => s.X == attack.X && s.Y == attack.Y)
                .FirstOrDefault();

            if (segment != null)
            {
                segment.IsHit = true;
                return;
            }

            computerAttacks.Add(attack);
        }
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
            
            int row = line[0] - 'A';

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
                Y = int.Parse(line[1].ToString()) - 1
            };

        }
        while (true);

    }

    private string GetMapCharacter(int x, int y, bool isPlayerGrid)
    {
        if (isPlayerGrid)
        {
            if(computerAttacks.Contains(new Attack {X=x, Y=y}))
            {
                return "#";
            }

            var segment = playerShips
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
            if (playerAttacks.Contains(new Attack { X = x, Y = y }))
            {
                return "#";
            }

            var segment = computerShips
                .SelectMany(x => x.Segments)
                .Where(s => s.X == x && s.Y == y /*&& s.IsHit*/)
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
