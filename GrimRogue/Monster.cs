namespace GrimRogue;

public class Monster
{
    public string Name { get; private set; }
    public int HP { get; private set; }
    public int AC { get; private set; }
    public int ATK { get; private set; }
    public int SPD { get; private set; }
    
    public Monster(string name, int hp, int ac, int atk, int spd)
    {
        Name = name;
        HP = hp;
        AC = ac;
        ATK = atk;
        SPD = spd;
    }

    public void Hit(int damage)
    {
        HP -= damage;
    }

    public int DMG()
    {
        return 1; // Unarmed attack deals 1 damage
    }
}