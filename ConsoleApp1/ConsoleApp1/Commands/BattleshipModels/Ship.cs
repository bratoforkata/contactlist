namespace ConsoleApp1.Commands.BattleshipModels;

public class Ship
{
    public int Size { get; set; }
    public bool IsSunk { get; set; }

    public Segment[] Segments { get; set; } = [];
}
