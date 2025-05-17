using System.Diagnostics;

// ReSharper disable MemberCanBePrivate.Global

namespace TDHK.Common.Models;

[DebuggerDisplay("{DisplayText}")]
public class Race
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int HitPoints { get; private set; }
    public int StrengthBonus { get; private set; }
    public int InsightBonus { get; private set; }
    public int IntelligenceBonus { get; private set; }
    public int CharismaBonus { get; private set; }
    public int MovementRange { get; private set; }
    public string Skill { get; private set; }
    public string DisplayText => $"{Id} - {Name}";

    public override string ToString()
    {
        return DisplayText;
    }

    private Race(int id, string name, int hitPoints, int strengthBonus, int insightBonus, int intelligenceBonus, int charismaBonus, int movementRange, string skill)
    {
        Id = id;
        Name = name;
        HitPoints = hitPoints;
        StrengthBonus = strengthBonus;
        InsightBonus = insightBonus;
        IntelligenceBonus = intelligenceBonus;
        CharismaBonus = charismaBonus;
        MovementRange = movementRange;
        Skill = skill;
    }

    #region Data

    public static readonly Race HumanVillager = new(1, "Human (Villager)", 10, 2, 1, 2, 2, 2, "Because of the varying nature and versatility of humans, there are several types to choose from, each with their own special skills. Villagers can rotate on the flower stage once for no movement cost per turn.");
    public static readonly Race HumanMiko = new(2, "Human (Miko)", 10, 2, 1, 2, 2, 2, "Because of the varying nature and versatility of humans, there are several types to choose from, each with their own special skills. Miko can, twice per session, gain +3 to their danmaku OR dodge scores for one attack.");
    public static readonly Race HumanOutsider = new(3, "Human (Outsider)", 10, 2, 1, 2, 2, 2, "Because of the varying nature and versatility of humans, there are several types to choose from, each with their own special skills. Outsiders have 3 Dice, but only for basic attacks.");
    public static readonly Race HumanHourai = new(4, "Human (Hourai Immortal)", 35, 2, 1, 2, 2, 2, "Because of the varying nature and versatility of humans, there are several types to choose from, each with their own special skills. Hourai Immortals start with 35HP, but their lives are divided into 20HP sections as opposed to 10.");
    public static readonly Race Youkai = new(5, "Youkai", 15, 3, 2, 1, 1, 2, "Once per combat, you may set your turn in the turn order during combat. This lasts for a single turn.");
    public static readonly Race Ghost = new(6, "Ghost", 10, 1, 3, 2, 1, 3, "You may move through solid objects that are not ghosts, even in combat, and also move diagonally on the Flower Stage.");
    public static readonly Race Fairy = new(7, "Fairy", 10, 1, 3, 1, 2, 2, "Fairies take their damage at the beginning of their turn after it would normally be applied.");
    public static readonly Race Vampire = new(8, "Vampire", 15, 3, 1, 2, 1, 3, "Vampires will survive one attack per session that would normally drop them to 0 HP with 1 HP.");
    public static readonly Race Oni = new(9, "Oni", 15, 4, 1, 1, 1, 2, "Oni start combat with an extra 5 tension.");
    public static readonly Race Tengu = new(10, "Tengu", 10, 2, 2, 2, 1, 3, "Tengu may, once per session, make two move actions in one round.");
    public static readonly Race MoonRabbit = new(11, "Moon Rabbit", 10, 1, 3, 2, 1, 2, "Moon Rabbits may, once per session, add half their Perception score to any one ability score, including Danmaku or Dodge.");
    public static readonly Race Amanojaku = new(12, "Amanojaku", 10, 3, 2, 2, 0, 2, "Amanojaku may, once per session, reverse the roll modifiers for a single target.");
    public static readonly Race Inchling = new(13, "Inchling", 10, 1, 2, 2, 2, 2, "Inchlings gain an extra +1 to their dodge score.");
    public static readonly Race Kappa = new(14, "Kappa", 10, 2, 1, 3, 1, 2, "Kappa may, thrice per combat, choose to attack any two enemies in their normal attack range as opposed to one.");
    public static readonly Race Halfyoukai = new(15, "Half-Youkai", 10, 2, 2, 1, 2, 2, "A Half-Youkai can, once per session, transform. The effects of this transformation raise one core attribute by 2, specified beforehand, lowers another by 2, and increase move by 1. This lasts six turns in combat.");
    public static readonly Race Satori = new(16, "Satori", 10, 1, 3, 3, 0, 2, "Satori may, twice a session, re-do any roll. They must keep the new result, however.");
    public static readonly Race Celestial = new(17, "Celestial", 15, 2, 1, 1, 3, 2, "Celestials may choose to go last in combat, but get an additional +2 to their danmaku score for the first 4 turns of that combat.");
    public static readonly Race God = new(18, "God", 20, 1, 3, 1, 2, 2, "Gods gather Faith as well as Tension. Whenever a god gains 4 or more Tension or casts a spell card, they gain 1 Faith, and whenever they lose 4 or more Tension as a penalty, they lose 1 Faith. Faith grants the following effects: At 3 Faith, a God gains +1 to Danmaku or Dodge. The God is stuck with this choice until they drop below 3 Faith. At 6 Faith, a God gains +1 Move. At 9 Faith, a God can convert their stored Faith to Tension, and begin gaining double the Faith. At 12 Faith, a God may cast any one spell card they have, spending all their Faith as a substitue for the Tension cost. ");
    public static readonly Race Hermit = new(19, "Hermit", 15, 0, 2, 3, 2, 2, "Hermits, thrice per session, may heal 5 HP instantly.");
    public static readonly Race Shinigami = new(20, "Shinigami", 15, 1, 3, 0, 3, 3, "Twice per session, Shinigami may add 1d6 damage to their Danmaku roll, but only if the opponent does not dodge. This extra damage goes through Life barriers.");
    public static readonly Race Arahitogami = new(21, "Arahitogami", 10, 2, 3, 1, 1, 2, "Arahitogami may use the power of their Faith in order to power themselves up in combat. Once per session, they can make an attack that, hit or miss, will attack the target again on their next turn with the original Danmaku roll in addition to their normal attack.");
    public static readonly Race Tsukumogami = new(22, "Tsukumogami", 10, 1, 0, 3, 3, 2, "Once per session, you may choose to automatically fail one judgement; if you do, gain tension equal to your roll total.");
    public static readonly Race Lunarian = new(23, "Lunarian", 15, 1, 1, 4, 1, 2, "Lunarians may once per session, force a single judgement -- either combat or general -- to be a Graze.");
    public static readonly Race EarthRabbit = new(24, "Earth Rabbit", 10, 0, 4, 1, 2, 3, "Whenever you roll a critical or Graze during combat, flip a coin. On heads, double your tension gain.");
    public static readonly Race Tanuki = new(25, "Tanuki", 10, 1, 2, 3, 1, 2, "Once per session, you may choose any race you have encountered and use its special skill once with reduced effects. Any bonuses are halved with a minimum of 1, and any effects that you can use more than once may only be used one time.");


    public static readonly List<Race> Races =
    [
        HumanVillager,
        HumanMiko,
        HumanOutsider,
        HumanHourai,
        Youkai,
        Ghost,
        Fairy,
        Vampire,
        Oni,
        Tengu,
        MoonRabbit,
        Amanojaku,
        Inchling,
        Kappa,
        Halfyoukai,
        Satori,
        Celestial,
        God,
        Hermit,
        Shinigami,
        Arahitogami,
        Tsukumogami,
        Lunarian,
        EarthRabbit,
        Tanuki
    ];

    #endregion
}