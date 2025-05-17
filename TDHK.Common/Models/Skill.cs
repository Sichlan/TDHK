using System.Diagnostics;

// ReSharper disable MemberCanBePrivate.Global

namespace TDHK.Common.Models;

[DebuggerDisplay("{DisplayText}")]
public class Skill
{
    public int Id { get; private init; }
    public string Name { get; private init; }
    public SkillType SkillType { get; private init; }
    public List<SkillStage> SkillStages { get; private init; }
    public string DisplayText => $"{Id} - {Name}";

    private Skill(int id, string name, SkillType skillType, List<SkillStage> skillStages)
    {
        Id = id;
        Name = name;
        SkillType = skillType;
        SkillStages = skillStages;
    }

    #region Data

    public static readonly Skill Conversationalist = new(1, "Conversationalist", SkillType.General, [
        new SkillStage(1, 3, "+1 to all  social interactions", styleRequirement: 10),
        new SkillStage(2, 5, "+2 to all  social interactions", styleRequirement: 12),
        new SkillStage(3, 7, "+3 to all  social interactions", styleRequirement: 14),
        new SkillStage(4, 10, "+4 to all  social interactions", styleRequirement: 16),
        new SkillStage(5, 12, "+5 to all  social interactions", styleRequirement: 18)
    ]);
    public static readonly Skill EagleEyes = new(2, "Eagle Eyes", SkillType.General, [
        new SkillStage(1, 3, "+1 to Per. checks to see/hear things", perceptionRequirement: 7),
        new SkillStage(2, 5, "+2 to Per. checks to see/hear things", perceptionRequirement: 9),
        new SkillStage(3, 7, "+3 to Per. checks to see/hear things", perceptionRequirement: 12),
        new SkillStage(4, 10, "+4 to Per. checks to see/hear things", perceptionRequirement: 14),
        new SkillStage(5, 12, "+5 to Per. checks to see/hear things", perceptionRequirement: 15)
    ]);
    public static readonly Skill LieDetector = new(3, "Lie Detector", SkillType.General, [
        new SkillStage(1, 3, "+1 to tell if statement is truth", insightRequirement: 5),
        new SkillStage(2, 5, "+2 to tell if statement is truth", insightRequirement: 7, intelligenceRequirement: 7),
        new SkillStage(3, 7, "+3 to tell if statement is truth", insightRequirement: 10, intelligenceRequirement: 10),
        new SkillStage(4, 10, "+4 to tell if statement is truth", insightRequirement: 12, intelligenceRequirement: 12),
        new SkillStage(5, 12, "+5 to tell if statement is truth", insightRequirement: 14, intelligenceRequirement: 14)
    ]);
    public static readonly Skill Persuasion = new(4, "Persuasion", SkillType.General, [
        new SkillStage(1, 3, "+1 to coercion or intimidation"),
        new SkillStage(2, 5, "+2 to coercion or intimidation"),
        new SkillStage(3, 7, "+3 to coercion or intimidation"),
        new SkillStage(4, 10, "+4 to coercion or intimidation"),
        new SkillStage(5, 12, "+5 to coercion or intimidation")
    ]);
    public static readonly Skill Burglary = new(5, "Burglary", SkillType.General, [
        new SkillStage(1, 3, "+1 to acts of thievery/lockpicking", reflexRequirement: 8),
        new SkillStage(2, 5, "+2 to acts of thievery/lockpicking", reflexRequirement: 10),
        new SkillStage(3, 7, "+3 to acts of thievery/lockpicking", reflexRequirement: 12),
        new SkillStage(4, 10, "+4 to acts of thievery/lockpicking", reflexRequirement: 14),
        new SkillStage(5, 12, "+5 to acts of thievery/lockpicking", reflexRequirement: 15)
    ]);
    public static readonly Skill Scavenger = new(6, "Scavenger", SkillType.General, [
        new SkillStage(1, 3, "+1 to find hidden items", perceptionRequirement: 5),
        new SkillStage(2, 5, "+2 to find hidden items", perceptionRequirement: 8),
        new SkillStage(3, 7, "+3 to find hidden items", perceptionRequirement: 10),
        new SkillStage(4, 10, "+4 to find hidden items", perceptionRequirement: 12),
        new SkillStage(5, 12, "+5 to find hidden items", perceptionRequirement: 14)
    ]);
    public static readonly Skill Tamer = new(7, "Tamer", SkillType.General, [
        new SkillStage(1, 3, "+1 to interaction with animals", charismaRequirement: 5),
        new SkillStage(2, 5, "+2 to interaction with animals", charismaRequirement: 7),
        new SkillStage(3, 7, "+3 to interaction with animals", charismaRequirement: 10),
        new SkillStage(4, 10, "+4 to interaction with animals", charismaRequirement: 12),
        new SkillStage(5, 12, "+5 to interaction with animals", charismaRequirement: 14)
    ]);
    public static readonly Skill Metalworking = new(8, "Metalworking", SkillType.General, [
        new SkillStage(1, 3, "+1 to crafting an item of decent make", strengthRequirement: 7, intelligenceRequirement: 9),
        new SkillStage(2, 5, "+2 to crafting an item of decent make", strengthRequirement: 10, intelligenceRequirement: 12),
        new SkillStage(3, 7, "+3 to crafting an item of decent make", strengthRequirement: 12, intelligenceRequirement: 14),
        new SkillStage(4, 10, "+4 to crafting an item of decent make", strengthRequirement: 14, intelligenceRequirement: 15),
        new SkillStage(5, 12, "+5 to crafting an item of decent make", strengthRequirement: 15, intelligenceRequirement: 16)
    ]);
    public static readonly Skill HistoryTeacher = new(9, "History Teacher", SkillType.General, [
        new SkillStage(1, 3, "+1 to knowledge of historical events.", intelligenceRequirement: 8),
        new SkillStage(2, 5, "+2 to knowledge of historical events.", intelligenceRequirement: 10),
        new SkillStage(3, 7, "+3 to knowledge of historical events.", intelligenceRequirement: 12),
        new SkillStage(4, 10, "+4 to knowledge of historical events.", intelligenceRequirement: 14),
        new SkillStage(5, 12, "+5 to knowledge of historical events.", intelligenceRequirement: 15)
    ]);
    public static readonly Skill YoukaiExpert = new(10, "Youkai Expert", SkillType.General, [
        new SkillStage(1, 3, "+1 to identifying an unknown type of youkai", insightRequirement: 5, perceptionRequirement: 10),
        new SkillStage(2, 5, "+2 to identifying an unknown type of youkai", insightRequirement: 7, perceptionRequirement: 12),
        new SkillStage(3, 7, "+3 to identifying an unknown type of youkai", insightRequirement: 10, perceptionRequirement: 14),
        new SkillStage(4, 10, "+4 to identifying an unknown type of youkai", insightRequirement: 12, perceptionRequirement: 16),
        new SkillStage(5, 12, "+5 to identifying an unknown type of youkai", insightRequirement: 14, perceptionRequirement: 18)
    ]);
    public static readonly Skill FriendToHumans = new(11, "Friend To Humans", SkillType.General, [
        new SkillStage(1, 5, "+2 to interactions with humans, but -2 to non-humans", charismaRequirement: 5, styleRequirement: 10),
        new SkillStage(2, 7, "+3 to interactions with humans, but -2 to non-humans", charismaRequirement: 7, styleRequirement: 12),
        new SkillStage(3, 10, "+4 to interactions with humans, but -3 to non-humans", charismaRequirement: 10, styleRequirement: 14),
        new SkillStage(4, 12, "+5 to interactions with humans, but -3 to non-humans", charismaRequirement: 12, styleRequirement: 16),
        new SkillStage(5, 14, "+6 to interactions with humans, but -4 to non-humans", charismaRequirement: 14, styleRequirement: 18)
    ]);
    public static readonly Skill YoukaiAdvocate = new(12, "Youkai Advocate", SkillType.General, [
        new SkillStage(1, 5, "+2 to interactions with non-humans, -2 to humans", charismaRequirement: 5, styleRequirement: 10),
        new SkillStage(2, 7, "+3 to interactions with non-humans, -2 to humans", charismaRequirement: 7, styleRequirement: 12),
        new SkillStage(3, 10, "+4 to interactions with non-humans, -3 to humans", charismaRequirement: 10, styleRequirement: 14),
        new SkillStage(4, 12, "+5 to interactions with non-humans, -3 to humans", charismaRequirement: 12, styleRequirement: 16),
        new SkillStage(5, 14, "+6 to interactions with non-humans, -4 to humans", charismaRequirement: 14, styleRequirement: 18)
    ]);
    public static readonly Skill DanmakuVeteran = new(13, "Danmaku Veteran", SkillType.Combat, [
        new SkillStage(1, 5, "+1 to all danmaku rolls", strengthRequirement: 12)
    ]);
    public static readonly Skill Speedy = new(14, "Speedy", SkillType.Combat, [
        new SkillStage(1, 3, "+1 to Move score", reflexRequirement: 15),
        new SkillStage(2, 5, "+2 to move score", reflexRequirement: 20)
    ]);
    public static readonly Skill ReadingAttacks = new(15, "Reading Attacks", SkillType.Combat, [
        new SkillStage(1, 3, "+1 to Dodge rolls", strengthRequirement: 10, insightRequirement: 10, intelligenceRequirement: 10, charismaRequirement: 10),
        new SkillStage(2, 5, "+2 to Dodge rolls", strengthRequirement: 12, insightRequirement: 12, intelligenceRequirement: 12, charismaRequirement: 12),
        new SkillStage(3, 7, "+3 to Dodge rolls", strengthRequirement: 14, insightRequirement: 14, intelligenceRequirement: 14, charismaRequirement: 14)
    ]);
    public static readonly Skill Adrenaline = new(16, "Adrenaline", SkillType.Combat, [
        new SkillStage(1, 5, "+1 to Move and +2 to Danmaku for 3 turns at  combat start, -1 to danmaku after")
    ]);
    public static readonly Skill Infighter = new(17, "Infighter", SkillType.Combat, [
        new SkillStage(1, 5, "You may add 1/3 your Str. score, rounded down,  to a danmaku roll once per  combat", strengthRequirement: 12)
    ]);
    public static readonly Skill EducatedGuess = new(18, "Educated Guess", SkillType.Combat, [
        new SkillStage(1, 5, "Once per combat, add 1/3 your Int. score to one  Dodge roll, rounded down", intelligenceRequirement: 12)
    ]);
    public static readonly Skill Disarming = new(19, "Disarming", SkillType.Combat, [
        new SkillStage(1, 5, "Once per combat, a foe attacking you gets -3 to Danmaku", charismaRequirement: 12)
    ]);
    public static readonly Skill RiskyGrazing = new(20, "Risky Grazing", SkillType.Combat, [
        new SkillStage(1, 5, "Once per combat, when you gain tension, gain 5 more", insightRequirement: 12)
    ]);
    public static readonly Skill Berserk = new(21, "Berserk", SkillType.Combat, [
        new SkillStage(1, 3, "Activating berserk gives +1 Die and +1 to Danmaku rolls only, but you take a -3  penalty to Dodge rolls.", strengthRequirement: 10)
    ]);
    public static readonly Skill FocusedMovement = new(22, "Focused Movement", SkillType.Combat, [
        new SkillStage(1, 3, "Activating gives+1 Die and +1 to Dodge rolls, but take a -2 penalty to Danmaku and -1 Move", intelligenceRequirement: 10, insightRequirement: 10)
    ]);
    public static readonly Skill Decoy = new(23, "Decoy", SkillType.Combat, [
        new SkillStage(1, 3, "Enemies get -2 to hit a chosen ally, but +1 to hit you.", charismaRequirement: 10)
    ]);
    public static readonly Skill PainTolerance = new(24, "Pain Tolerance", SkillType.Combat, [
        new SkillStage(1, 7, "-1 to all damage done to you above 1")
    ]);
    public static readonly Skill Support = new(25, "Support", SkillType.Combat | SkillType.General, [
        new SkillStage(1, 5, "you may choose to give another character up to 10  tension once per session")
    ]);
    public static readonly Skill DangerousBeauty = new(26, "Dangerous Beauty", SkillType.Combat, [
        new SkillStage(1, 10, "once per session, double your own roll results for 1 turn. Halve all others")
    ]);
    public static readonly Skill Gossip = new(27, "Gossip", SkillType.General, [
        new SkillStage(1, 1, "if you don't know what to do next, you may get a hint from the GM")
    ]);
    public static readonly Skill Blessing = new(28, "Blessing", SkillType.General, [
        new SkillStage(1, 3, "when a character gets a  critical, you may give them up  to 5 points of your tension")
    ]);
    public static readonly Skill Roulette = new(29, "Roulette", SkillType.General, [
        new SkillStage(1, 5, "Twice a session all players roll 2d6, highest result gets 3 tension from the GM")
    ]);
    public static readonly Skill FranticOffense = new(30, "Frantic Offense", SkillType.Combat, [
        new SkillStage(1, 7, "For every 5HP you've lost gain +1 to danmaku score"),
        new SkillStage(2, 10, "For every 5HP you've lost, gain +1 to danmaku score and dodge")
    ]);
    public static readonly Skill ViciousCycle = new(31, "Vicious Cycle", SkillType.Combat, [
        new SkillStage(1, 5, "For every 2 attacks you dodge in succession you gain +1 to your danmaku score")
    ]);
    public static readonly Skill Conversion = new(32, "Conversion", SkillType.General | SkillType.Combat, [
        new SkillStage(1, 10, "once per session you  may move 5 points of one core stat to another core stat.  lasts 3mins/3rds of combat")
    ]);
    public static readonly Skill Nurse = new(33, "Nurse", SkillType.General | SkillType.Combat, [
        new SkillStage(1, 5, "You may convert 5 points of your tension to heal 1 point of damage to you or any ally", charismaRequirement: 8),
        new SkillStage(2, 10, "12 Charisma, You may convert 5 points of  your tension to heal 2 pts of damage to yourself/ally")
    ]);
    public static readonly Skill Rally = new(34, "Rally", SkillType.Combat, [
        new SkillStage(1, 7, "once per session, all allies gain +1 movement and +1 dodge for 3 rounds of combat", charismaRequirement: 7),
        new SkillStage(2, 10, "10 Charisma, increase to +2 movement and +2 dodge")
    ]);
    public static readonly Skill WarCry = new(35, "War Cry", SkillType.Combat, [
        new SkillStage(1, 7, "Once per session all allies gain +2 danmaku for 2 rounds", charismaRequirement: 7),
        new SkillStage(2, 10, "10 Charisma, as before, but allies now reduce incoming damage by 1")
    ]);
    public static readonly Skill ExtraLuck = new(36, "Extra Luck", SkillType.General | SkillType.Combat, [
        new SkillStage(1, 10, "Once per session, pick an ally; they gain +1 die for 10mins/2rds", charismaRequirement: 12)
    ]);
    public static readonly Skill PoisonousWords = new(37, "Poisonous Words", SkillType.Combat, [
        new SkillStage(1, 7, "roll contest of intelligence on one enemy; if you win, that enemy gets -3 danmaku for 2rounds", intelligenceRequirement: 7)
    ]);
    public static readonly Skill Snare = new(38, "Snare", SkillType.Combat, [
        new SkillStage(1, 10, "once per combat choose one enemy; it cannot move for 1d6 rounds", intelligenceRequirement: 10)
    ]);
    public static readonly Skill WallOfThought = new(39, "Wall of Thought", SkillType.General | SkillType.Combat, [
        new SkillStage(1, 7, "once per session you may create a wall of magic. Out of combat it is 10ft wide and 10ft tall; in combat it occupies two adjacent squares", intelligenceRequirement: 8)
    ]);
    public static readonly Skill DirtyTrick = new(40, "Dirty Trick", SkillType.Combat, [
        new SkillStage(1, 7, "once per combat roll danmaku; if you hit, enemy takes -2 to dodge on the next attack", intelligenceRequirement: 7)
    ]);
    public static readonly Skill PointDeviceMode = new(41, "Point-Device Mode", SkillType.Combat, [
        new SkillStage(1, 12, "Once per session you can ignore the life barrier on ONE attack, up to 30 damage")
    ]);
    public static readonly Skill EvensOrOdds = new(42, "Evens or Odds?", SkillType.Combat, [
        new SkillStage(1, 7, "3 times per session you may roll 1d6 and declare even or odd; if you're right gain your result as a bonus to danmaku. If you're wrong, lose your result as a penalty to it.")
    ]);
    public static readonly Skill HighOrLow = new(43, "High or Low?", SkillType.General | SkillType.Combat, [
        new SkillStage(1, 7, "2 times per session, you can roll 2d6. If your result is  7 or above, gain that much tension.  If it is below 7, lose that much tension. If your result is 12, gain 1 XP.")
    ]);
    public static readonly Skill PurpleProdigy = new(44, "Purple Prodigy", SkillType.Combat, [
        new SkillStage(1, 10, "If you are adjacent to the edge of the flower stage you may move to the opposite side, using one movement.")
    ]);
    public static readonly Skill IntangibleMovement = new(45, "Intangible Movement", SkillType.Combat, [
        new SkillStage(1, 8, "You may move through obstacles on the flower stage, but may not end your movement inside of them.")
    ]);
    public static readonly Skill Stabilize = new(46, "Stabilize", SkillType.General | SkillType.Combat, [
        new SkillStage(1, 7, "Once per combat, until your next turn, all your rolls are guaranteed to be 7, not counting modifiers.")
    ]);
    public static readonly Skill ScarletMistIncident = new(47, "Scarlet Mist Incident", SkillType.General | SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "You may spread a fog  that obscures vision; gives -1 to dodge and danmaku to those inside of it. Cannot be used when under 15HP.", raceIdRequirement: [1,2,3,4,5,8])
    ]);
    public static readonly Skill SpringSnowIncident = new(48, "Spring Snow Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "grants a barrier that activates after scoring 3 hits with basic attacks; negates 1 enemy attack that would otherwise deal damage.", raceIdRequirement: [1,2,3,4,6])
    ]);
    public static readonly Skill EternalNightIncident = new(49, "Eternal Night Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "You may attack all squares in your basic attack range in one attack for half damage, min 1. Only at night.", raceIdRequirement: [11,15,23])
    ]);
    public static readonly Skill SixtyYearCycleGreatBarrierIncident = new(50, "Sixty-Year Cycle Great Barrier Incident", SkillType.Combat, [
        new SkillStage(1, 10, "If your HP total is even, when you KO an enemy with a basic attack, you may roll an attack on any other enemy in your basic attack range.", raceIdRequirement: [18,20,24])
    ]);
    public static readonly Skill MoriyaShrineIncident = new(51, "Moriya Shrine Incident", SkillType.Combat, [
        new SkillStage(1, 10, "If your HP total is odd, Once every other turn you can spend 10 tension to negate 1 hit on yourself.", raceIdRequirement: [10,14,18,21])
    ]);
    public static readonly Skill EarthquakeIncident = new(52, "Earthquake Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "If the weather is sunny, increase your dodge score by 2.", raceIdRequirement: [7,17,18])
    ]);
    public static readonly Skill FormerHellIncident = new(53, "Former Hell Incident", SkillType.General | SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "If you are not first in the turn order, once per session you can force the opponent to have a roll total of 6.", raceIdRequirement: [5,9,16])
    ]);
    public static readonly Skill TreasureShipIncident = new(54, "Treasure Ship Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "Every time you dodge 3 attacks you can choose to either gain 5 tension, heal 5HP or gain one extra die for 2 rounds.", raceIdRequirement: [1,2,3,4,6,22])
    ]);
    public static readonly Skill DivineSpiritIncident = new(55, "Divine Spirit Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "Every time you move 10 squares in combat, add +2 to your danmaku score.", raceIdRequirement: [1,2,3,4,19,25])
    ]);
    public static readonly Skill ReligiousWarIncident = new(56, "Religious War Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "If combat has spectators gain +2 to your movement score.", raceIdRequirement: [1,2,3,4,14,16,19,25])
    ]);
    public static readonly Skill SocialReversalIncident = new(57, "Social Reversal Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "If you are on your last life, switch HP totals with an ally who is not.", raceIdRequirement: [12,13,22])
    ]);
    public static readonly Skill UrbanLegendIncident = new(58, "Urban Legend Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "You can spend 10 tension to activate one of the following effects: +3 to danmaku for one attack, heal 5hp, +3 to dodge for one attack, create an obstacle between you and an opponent, two basic attacks for one action at -4 to danmaku.", raceIdRequirement: [1,2,3,4,6,11,14,19,25])
    ]);
    public static readonly Skill SecondLunarIncident = new(59, "Second Lunar Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, " Every Graze you get also reduces damage of the next hit by 4, to a minimum of 1.", raceIdRequirement: [1,2,3,4,11,18,21])
    ]);
    public static readonly Skill FourSeasonsIncident = new(60, "Four Seasons Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "Once per combat you may instantly move to within your basic attack range for one enemy. You must not have moved more than 5 spaces yet.", raceIdRequirement: [1,2,3,4,7,10])
    ]);
    public static readonly Skill PerfectPossessionIncident = new(61, "Perfect Possession Incident", SkillType.Combat | SkillType.Incident, [
        new SkillStage(1, 10, "for every ally  you are adjacent to, you gain +1 to danmaku and dodge.")
    ]);


    public static readonly List<Skill> Skills =
    [
        Conversationalist,
        EagleEyes,
        LieDetector,
        Persuasion,
        Burglary,
        Scavenger,
        Tamer,
        Metalworking,
        HistoryTeacher,
        YoukaiExpert,
        FriendToHumans,
        YoukaiAdvocate,
        DanmakuVeteran,
        Speedy,
        ReadingAttacks,
        Adrenaline,
        Infighter,
        EducatedGuess,
        Disarming,
        RiskyGrazing,
        Berserk,
        FocusedMovement,
        Decoy,
        PainTolerance,
        Support,
        DangerousBeauty,
        Gossip,
        Blessing,
        Roulette,
        FranticOffense,
        ViciousCycle,
        Conversion,
        Nurse,
        Rally,
        WarCry,
        ExtraLuck,
        PoisonousWords,
        Snare,
        WallOfThought,
        DirtyTrick,
        PointDeviceMode,
        EvensOrOdds,
        HighOrLow,
        PurpleProdigy,
        IntangibleMovement,
        Stabilize,
        ScarletMistIncident,
        SpringSnowIncident,
        EternalNightIncident,
        SixtyYearCycleGreatBarrierIncident,
        MoriyaShrineIncident,
        EarthquakeIncident,
        FormerHellIncident,
        TreasureShipIncident,
        DivineSpiritIncident,
        ReligiousWarIncident,
        SocialReversalIncident,
        UrbanLegendIncident,
        SecondLunarIncident,
        FourSeasonsIncident,
        PerfectPossessionIncident
    ];

    #endregion
}