using System;

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
              //.SpawnShip(gridSize, 5, red)
              //.SpawnShip(gridSize, 4, red)
              //.SpawnShip(gridSize, 3, red)
              //.SpawnShip(gridSize, 3, red)
              //.SpawnShip(gridSize, 2, red)
              //.SpawnShip(gridSize, 7, red)
              //.SpawnShip(gridSize, 6, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red)
              .SpawnShip(gridSize, 1, red);
    }

    public static void Debug(IEnumerable<int> red, IEnumerable<int> green, IEnumerable<int> blue, int gridSize)
    {
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                int index = y * gridSize + x;

                Console.ResetColor();

                if (blue.Contains(index))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                if (green.Contains(index))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (red.Contains(index))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write("█");
            }
            Console.WriteLine();
        }
        Console.ResetColor();
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
                Console.WriteLine("insufficient space");
                break;
            }

        } while (true);


        while (blue.Count != shipSize)
        {
            green.Clear();
            blue.Add(index);
            green.Remove(index);

            GetNeighbours(red, green, blue, gridSize, index);

            Debug(red, green, blue, gridSize);

            if (blue.Count == shipSize)
            {
                continue;
            }

            if (green.Count == 0)
            {
                break;
            }

            index = green[Random.Shared.Next(green.Count)];
        }



        //  GetNeighbours(red, green, blue, gridSize, index);

        Debug(red, green, blue, gridSize);

        foreach (var i in blue)
        {
            red.Add(i); // TODO: add diagonals
        }

        Debug(red, green, blue, gridSize);

        foreach (var i in green)
        {
            red.Add(i);
        }

        Debug(red, green, blue, gridSize);

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
        TryAdd(-1);
        TryAdd(+1);
        TryAdd(-gridSize);
        TryAdd(+gridSize);



        void TryAdd(int offSet)
        {
            var i = index + offSet;
            var remainderIndex = index % gridSize;
            var remainderOffSet = i % gridSize;

            if (remainderIndex != remainderOffSet)
            {
                if (remainderIndex + offSet < 0)
                {
                    return;
                }
                if (remainderIndex + offSet >= gridSize)
                {
                    return;
                }
            }

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

    private static bool ValidateIndex(HashSet<int> red, int gridSize, int shipSize, int index)
    {
        HashSet<int> orange = new HashSet<int>();

        int prevCount = orange.Count;

        TryAdd(0, index);

        if (orange.Count == prevCount)
        {
            return false;
        }

        while (shipSize != orange.Count)
        {
            prevCount = orange.Count;

            var temp = orange.ToArray();

            foreach (var number in temp)
            {
                TryAdd(1, number);
                TryAdd(gridSize, number);
                TryAdd(-1, number);
                TryAdd(-gridSize, number);
            }

            if (prevCount == orange.Count)
            {
                return false;
            }
        }



        return true;

        void TryAdd(int offSet, int currentIndex)
        {

            var i = currentIndex + offSet;
            var remainderIndex = currentIndex % gridSize;
            var remainderOffSet = i % gridSize;

            if (remainderIndex != remainderOffSet)
            {
                if (remainderIndex + offSet < 0)
                {
                    return;
                }
                if (remainderIndex + offSet >= gridSize)
                {
                    return;
                }
            }

            if (i < 0)
            {
                return;
            }
            if (i >= gridSize * gridSize)
            {
                return;
            }
            if (red.Contains(i))
            {
                return;
            }

            orange.Add(i);
        }
    }
}



