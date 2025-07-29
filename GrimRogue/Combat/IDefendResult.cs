using GrimRogue.CharList;

namespace GrimRogue.Combat;

public interface IDefendResult
{
    public Monster Attacker { get; }
    public Character Defender { get; }
    public int RollToDefend { get; }

}