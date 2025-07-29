using GrimRogue.CharList;

namespace GrimRogue.Combat;

public interface IAttackResult
{
    Character Attacker { get; }
    Monster Defender { get; }
    int RollToHit { get; }
}

public sealed record HitMonster(
    Character Attacker,
    Monster Defender,
    int RollToHit,
    int Damage) : IAttackResult;

public record MissMonster(
    Character Attacker,
    Monster Defender,
    int RollToHit) : IAttackResult;