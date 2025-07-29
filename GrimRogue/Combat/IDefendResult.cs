using GrimRogue.CharList;

namespace GrimRogue.Combat;

public interface IDefendResult
{
    public Monster Attacker { get; }
    public Character Defender { get; }
    public int RollToDefend { get; }
}

public record DeflectMonster(
    Monster Attacker,
    Character Defender,
    int RollToDefend) : IDefendResult;
    
public record HitByMonster(
    Monster Attacker,
    Character Defender,
    int RollToDefend,
    int Damage) : IDefendResult;