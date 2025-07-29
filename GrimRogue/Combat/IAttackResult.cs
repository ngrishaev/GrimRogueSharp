using GrimRogue.CharList;

namespace GrimRogue.Dice;

public interface IAttackResult
{
    Character Attacker { get; }
    Monster Monster { get; }
    int AtkRoll { get; }
}