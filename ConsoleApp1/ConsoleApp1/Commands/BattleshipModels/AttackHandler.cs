namespace ConsoleApp1.Commands.BattleshipModels;

public static class AttackHandler
{

    public static Attack GetAttack(int gridSize, List<Ship> ships, HashSet<Attack> attacks)
    {
        if (ships.Count == 0)
        {
            return GetPlayerAttack(gridSize);
        }
        return GetComputerAttack(gridSize, ships, attacks);
    }

    public static void MakeAttack(HashSet<Attack> attacks, Attack attack, List<Ship> ships, string player)
    {
        if (attacks.Contains(attack))
        {
            Console.WriteLine("you already attacked there!");
            return;
        }

        foreach (var ship in ships)
        {
            foreach (var segment in ship.Segments)
            {
                if (segment.X == attack.X && segment.Y == attack.Y)
                {
                    segment.IsHit = true;

                    if (ship.Size == ship.Segments.Count(x => x.IsHit))
                    {
                        ship.IsSunk = true;
                        Console.WriteLine($"{player} has sunk a ship!");
                    }
                }
            }
        }
        attacks.Add(attack);
    }

    private static Attack GetComputerAttack(int gridSize, List<Ship> ships, HashSet<Attack> attacks)
    {
        List<PotentialAttack> potential = new List<PotentialAttack>();


        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                if (attacks.Any(a => a.X == x && a.Y == y))
                {
                    continue;
                }

                var attackScore = GetAttackScore(x, y);
                var attack = new Attack { X = x, Y = y };
                var potentialAttack = new PotentialAttack(attackScore, attack);

                potential.Add(potentialAttack);

            }
        }

        var max = potential
            .Select(x => x.Score)
            .Max();

        var candidates = potential
            .Where(x => x.Score == max)
            .Select(x => x.Attack)
            .ToArray();

        return candidates[Random.Shared.Next(candidates.Length)];


        int GetAttackScore(int x, int y)
        {
            if (attacks.Any(a => a.X == x && a.Y == y))
            {
                return 0;
            }

            int result = 1;

            foreach (var ship in ships)
            {
                if (ship.IsSunk)
                {
                    continue;
                }
                foreach (var segment in ship.Segments)
                {
                    if (segment.IsHit == false)
                    {
                        continue;
                    }

                    if (segment.X == x - 1 && segment.Y == y)
                    {
                        result++;
                    }

                    if (segment.X == x + 1 && segment.Y == y)
                    {
                        result++;
                    }

                    if (segment.X == x && segment.Y == y - 1)
                    {
                        result++;
                    }

                    if (segment.X == x && segment.Y == y + 1)
                    {
                        result++;
                    }

                }


            }

            return result;
        }
    }

    private static Attack GetPlayerAttack(int gridSize)
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

            if (row >= gridSize)
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
}



