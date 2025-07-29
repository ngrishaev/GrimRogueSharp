using GrimRogue.CharList;

namespace GrimRogue.Combat;

public class CombatService()
{
    public IAttackResult AttackMonster(Character character, Monster monster)
    {
        var fixed6d = new Dice.Die(6, 6);
        var atkRoll = 2 * fixed6d.Roll() + character.Str;
        if (atkRoll >= monster.AC)
        {
            return new Hit(character.Name, monster.Name, atkRoll, character.Damage());
        }

        return new Miss(character.Name, monster.Name, atkRoll);
    }
    
}