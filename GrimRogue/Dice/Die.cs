namespace GrimRogue.Dice;

public class Die
{
    private readonly int _min;
    private readonly int _maxInclusive;
    private readonly Random _random;

    public Die(int min, int maxInclusive): this(min, maxInclusive, new Random())
    { }
    
    public Die(int min, int maxInclusive, Random random)
    {
        if(min > maxInclusive)
            throw new ArgumentException("Max must be greater than min.");
        
        _min = min;
        _maxInclusive = maxInclusive;
        _random = random;
    }

    public int Roll()
    {
        return _random.Next(_min, _maxInclusive + 1);
    }
    
    public static Die D6() => new Die(1, 6);
}