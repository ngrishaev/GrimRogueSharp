using GrimRogue.CharList;
using GrimRogue.Dice;

namespace GrimRogue.Combat;

public class CombatService()
{
    public IAttackResult AttackMonster(Character character, Monster monster)
    {
        var d6 = Die.D6();
        var atkRoll = 2 * d6.Roll() + character.Str;
        if (atkRoll >= monster.AC)
        {
            return new HitMonster(character, monster, atkRoll, character.Damage());
        }

        return new MissMonster(character, monster, atkRoll);
    }
    
    public IDefendResult DefendMonster(Character character, Monster monster)
    {
        var d6 = Die.D6();
        var defRoll = 2 * d6.Roll() + character.ArmorClass();
        if (defRoll >= monster.ATK)
        {
            return new DeflectMonster(monster, character, defRoll);
        }

        return new HitByMonster(monster, character, defRoll, monster.DMG());
    }
}