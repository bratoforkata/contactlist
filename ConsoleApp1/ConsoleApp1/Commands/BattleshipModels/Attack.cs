namespace ConsoleApp1.Commands.BattleshipModels;

public record Attack
{
    public int X { get; set; }
    public int Y { get; set; }

}

public record PotentialAttack(int Score, Attack Attack); // primary constructor - we can do it like that instead of line 3 to 8