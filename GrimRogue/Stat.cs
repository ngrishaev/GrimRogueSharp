namespace GrimRogue;

public class Stat
{
    public int Value { get; private set; }

    public Stat(int value)
    {
        Value = value;
    }

    public int Modifier()
    {
        return Value switch
        {
            <= 4 => -1,
            <= 7 => 0,
            <= 10 => 1,
            <= 12 => 2,
            _ => throw new InvalidOperationException("Stat value can't be greater than 12."),
        };
    }
}