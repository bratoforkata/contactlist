using ConsoleApp1.Commands.BattleshipModels;
using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;
using System.Text;

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
                .Where(s => s.X == attack.X && s.Y == attack.Y)
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
                continue; // add validation 
            }
            if (line.Length != 2)
            {
                continue;
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

    private static List<string> RenderBoard(IEnumerable<Segment> segments, IEnumerable<Attack> attacks)
    {
        var list = new List<string>();

        for (var y = 0; y < GridSize; y++)
        {
            var sb = new StringBuilder();

            for (int x = 0; x < GridSize; x++)
            {
                var segment = segments.Where(s => s.X == x && s.Y == y).FirstOrDefault();
                if (segment is not null)
                {
                    if (segment.IsHit)
                    {
                        sb.Append("X ");
                    }
                    else
                    {
                        sb.Append("O ");
                    }
                    continue;
                }

                if (attacks.Any(a => a.X == x && a.Y == y))
                {
                    sb.Append("# ");
                    continue;
                }

                sb.Append("⋅ ");
            }

            list.Add(sb.ToString());
        }


        return list;

    }


    private void PrintGrids()
    {
        string numbers = string.Join(" ", Enumerable.Range(1, GridSize));

        Console.WriteLine($"  {numbers}      {numbers}");  // Column headers

        var player = RenderBoard(playerShips.SelectMany(x => x.Segments), computerAttacks);
        var computer = RenderBoard(computerShips.SelectMany(x => x.Segments).Where(x => !x.IsHit), playerAttacks);

        for (int y = 0; y < GridSize; y++)
        {
            char row = (char)('A' + y);

            Console.WriteLine($"{row} {player[y]}     {computer[y]}");
        }
    }
}
