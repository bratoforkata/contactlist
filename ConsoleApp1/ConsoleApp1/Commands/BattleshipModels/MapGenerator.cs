namespace ConsoleApp1.Commands.BattleshipModels;

public static class MapGenerator
{
    public static Map GenerateMap(int gridSize)
    {
        return new Map
        {
            Player2 = GenerateShips(gridSize),
            Player1 = GenerateShips(gridSize)
        };
    }

    private static List<Ship> GenerateShips(int gridSize)
    {
        var red = new HashSet<int>();
        var list = new List<Ship>();

        return list
              .SpawnShip(gridSize, 5, red)
              .SpawnShip(gridSize, 4, red)
              .SpawnShip(gridSize, 3, red)
              .SpawnShip(gridSize, 3, red)
              .SpawnShip(gridSize, 2, red);
    }

    private static List<Ship> SpawnShip(this List<Ship> ships, int gridSize, int shipSize, HashSet<int> red)
    {
        var green = new List<int>();
        var blue = new HashSet<int>();

        var max = gridSize * gridSize;
        if (red.Count == max)
        {
            throw new Exception("atstas");
        }

        var index = -1;

        do
        {
            index = Random.Shared.Next(0, max);
            if (red.Contains(index))
            {
                continue;
            }

            if (ValidateIndex(red, gridSize, shipSize, index))
            {
                break;
            }

        } while (true);


        while (blue.Count != shipSize)
        {
            blue.Add(index);
            GetNeighbours(red, green, blue, gridSize, index);
            index = green[Random.Shared.Next(green.Count)];
            green.Remove(index);
        }

        foreach (var i in blue)
        {
            red.Add(i); // TODO: add diagonals
        }

        foreach (var i in green)
        {
            red.Add(i);
        }

        var ship = new Ship
        {
            IsSunk = false,
            Size = shipSize,
            Segments = GetSegments(blue, gridSize)
        };

        ships.Add(ship);

        return ships;
    }

    private static Segment[] GetSegments(HashSet<int> blue, int gridSize)
    {
        var array = new Segment[blue.Count];
        var index = 0;


        foreach (var i in blue)
        {
            var segment = new Segment
            {
                IsHit = false,
                X = i % gridSize, // modulus 
                Y = i / gridSize,
            };
            array[index++] = segment;
        }

        return array;
    }

    private static void GetNeighbours(HashSet<int> red, List<int> green, HashSet<int> blue, int gridSize, int index)
    {
        var mapSize = gridSize * gridSize;
        TryAdd(index - 1);
        TryAdd(index + 1);
        TryAdd(index - gridSize);
        TryAdd(index + gridSize);



        void TryAdd(int i)
        {
            if (i < 0)
            {
                return;
            }
            if (i >= mapSize)
            {
                return;
            }
            if (red.Contains(i))
            {
                return;
            }
            if (blue.Contains(i))
            {
                return;
            }
            if (green.Contains(i))
            {
                return;
            }

            green.Add(i);



        }
    }

    public static bool ValidateIndex(HashSet<int> red, int gridSize, int shipSize, int index)
    {
        //  we need to validate if there is enough space for a ship


        return true;
    }


}
