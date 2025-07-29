namespace GrimRogue.CharList;

public class StatBlock
{
    public Stat Strength { get; private set;}
    public Stat Dexterity { get; private set;}
    public Stat Constitution { get; private set;}
    public Stat Intelligence { get; private set;}

    public StatBlock(int strength, int dexterity, int constitution, int intelligence)
    {
        Strength = new Stat(strength);
        Dexterity = new Stat(dexterity);
        Constitution = new Stat(constitution);
        Intelligence = new Stat(intelligence);
    }
}

public class Character
{
    public string Name { get; private set;}
    public int Str => _stats.Strength.Modifier();
    public int Dex => _stats.Dexterity.Modifier();
    public int Con => _stats.Constitution.Modifier();
    public int Int => _stats.Intelligence.Modifier();
    private int MaxHp => 6 + 1 + Con; // d6 + 1 + CON
    public int CurrentHp { get; set; }
    private int InventoryCapacity => 8 + Str;
    private int Speed => 3 + Dex;
    private readonly StatBlock _stats;

    public Character(string name, int strength, int dexterity, int constitution, int intelligence)
    {
        Name = name;
        _stats = new StatBlock(strength, dexterity, constitution, intelligence);
        CurrentHp = MaxHp; 
    }

    public int Damage()
    {
        return 1; // Unarmed attack deals 1 damage
    }

    public int ArmorClass()
    {
        return 6; // Dunno, just a number, please check rulebook
    }

    public void Hit(int dmg)
    {
        CurrentHp -= dmg;
    }
}