using System.Diagnostics;

// ReSharper disable MemberCanBePrivate.Global

namespace TDHK.Common.Models;

[DebuggerDisplay("{DisplayText}")]
public class Flower
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public int StrengthBonus { get; private set; }
    public int InsightBonus { get; private set; }
    public int IntelligenceBonus { get; private set; }
    public int CharismaBonus { get; private set; }
    public string Skill { get; private set; }
    public int[] AttackRange { get; private set; }
    public List<string> Traits { get; private set; }
    public string Mutterings { get; private set; }
    public string DisplayText => $"{Id} - {Name}";

    public override string ToString()
    {
        return DisplayText;
    }

    private Flower(int id, string name, int strengthBonus, int insightBonus, int intelligenceBonus, int charismaBonus, string skill, int[] attackRange,
        List<string> traits, string mutterings)
    {
        Id = id;
        Name = name;
        StrengthBonus = strengthBonus;
        InsightBonus = insightBonus;
        IntelligenceBonus = intelligenceBonus;
        CharismaBonus = charismaBonus;
        Skill = skill;
        AttackRange = attackRange;
        Traits = traits;
        Mutterings = mutterings;
    }

    #region Data

    public static readonly Flower RoteRosa = new(1, "Rote Rosa", 4, 3, 2, 0,
        "At the start of combat, before anyone else acts, you may take one action.",
        [
            0, 0, 1, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 2, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        ],
        ["Passion", "Affection", "Ardent Love", "A Warm Heart", "Make Me Your Own", "I Love You"],
        "Since long ago, a light has been missing from my heart...");


    public static readonly Flower AmygdalusPersica = new(2, "Amygdalus Persica", 3, 4, 1, 1,
        "Twice per session, no matter the ruling, you score a hit. It does 2 damage, and you gain no tension.",
        [
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 1, 2, 1, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        ],
        ["A World Class Enemy of Fish", "The Spunky, Elegant Good Daughter", "I Have A Crush On You"],
        "Yesterday on the hill I was gathering nuts...");


    public static readonly Flower Lilium = new(3, "Lilium", 2, 2, 2, 3,
        "Once a session, you can use an enemy’s Spell Card by paying its full Tension cost. It is forgotten after the session.",
        [
            0, 0, 0, 0, 0,
            0, 1, 0, 1, 0,
            0, 0, 2, 0, 0,
            0, 1, 0, 1, 0,
            0, 0, 0, 0, 0
        ],
        ["With Purity and Without Disgrace", "Captivating Time", "Magnificent", "Pure", "Wise", "Dignified", "Perfection"],
        "From beyond Asahigaoka to just a little before your face...");


    public static readonly Flower PaeoniaSuffruticosa = new(4, "Paeonia Suffruticosa", 3, 0, 2, 4,
        "Once per session, when you take damage, you may also make your attacker receive this damage. It cannot be countered or healed.",
        [
            0, 0, 1, 0, 0,
            0, 0, 0, 0, 0,
            0, 1, 2, 1, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        ],
        ["Noble", "Shy", "Splendid", "Sincere", "Highly Placed"],
        "The world is overflowing with truths...");


    public static readonly Flower HelianthusAnnuus = new(5, "Helianthus Annuus", 1, 3, 3, 2,
        "Whenever you gain tension through combat, gain an additional 1d6 tension.",
        [
            0, 0, 0, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 2, 0, 0,
            0, 1, 0, 1, 0,
            0, 0, 0, 0, 0
        ],
        ["Gazing Upon You, You Are Magnificent", "Adoration", "Matured Love", "Vast Radiance", "Respectful Appeal"],
        "There’s an incredible person I know...");


    public static readonly Flower TrifoliumRepens = new(6, "Trifolium Repens", 0, 3, 2, 4,
        "You may use 3 skills as opposed to 2 during any judgement.",
        [
            0, 0, 0, 0, 0,
            0, 1, 0, 1, 0,
            0, 0, 2, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        ],
        ["Illusionary East", "Bliss", "Look At Me", "Think About Me"],
        "If compared, I am like a wind-ruffled grassland...");


    public static readonly Flower IrisSanguinea = new(7, "Iris Sanguinea", 1, 1, 4, 3,
        "You gain +1 on rolls for Initiative and +1 on all Perception rolls.",
        [
            0, 0, 0, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 2, 1, 0,
            0, 0, 0, 1, 0,
            0, 0, 0, 0, 0
        ],
        ["I’m Burning Up", "Good News", "Disappearing Thoughts", "Love Pleasant Work", "I’ll Treasure You"],
        "If compared, I am the wind. In that fashion, I change at will...");


    public static readonly Flower MyosotisAlpestris = new(8, "Myosotis Alpestris", 5, 1, 2, 1,
        "Spell Cards always cost 5 less tension.",
        [
            0, 0, 0, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 2, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 0, 0, 0
        ],
        ["True Friendship", "Admonishing Love", "Recollection"],
        "I have Power. I just about rule over everything on this Earth...");


    public static readonly Flower HibiscusSyriacus = new(9, "Hibiscus Syriacus", 0, 3, 3, 3,
        "At the beginning of each session, choose one player. Twice during that session, you may choose to take damage instead of that player’s character.",
        [
            0, 0, 0, 0, 0,
            0, 1, 1, 0, 0,
            0, 0, 2, 0, 0,
            0, 0, 1, 1, 0,
            0, 0, 0, 0, 0
        ],
        ["Femininity", "Delicate Beauty", "Gentle Strength", "Personal, Immortal Glory", "Sweet Disposition"],
        "A chair to sit in, a cup of tea to drink from, flowers to view...");


    public static readonly Flower HydrangeaMacrophylla = new(10, "Hydrangea Macrophylla", 3, 3, 3, 0,
        "Once per session, choose one of your allies at the beginning of the session. You may use their normal attack range for three turns of combat instead of your own.",
        [
            0, 0, 0, 0, 0,
            0, 0, 0, 1, 0,
            0, 0, 2, 1, 0,
            0, 0, 1, 1, 0,
            0, 0, 0, 0, 0
        ],
        ["Heartfelt Emotions", "Honesty", "Thank You For Understanding", "Boastfulness", "Enduring Beauty"],
        "A beautiful world is plagued by dishonesty, greed, pain, and judgement...");


    public static readonly Flower PogostemonCablin = new(11, "Pogostemon Cablin", 0, 2, 5, 2,
        "When making normal attacks, you may pay 4 tension for a +2 increase to your Danmaku stat. Each time you use this skill, it costs 4 more tension. This resets upon the end of the current session.",
        [
            0, 0, 1, 0, 0,
            0, 1, 0, 1, 0,
            0, 0, 2, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        ],
        ["I Am At Your Mercy", "Relaxation", "Happiness", "Rejuvenation Of Oneself", "Infatuation"],
        "My daily life was transformed. A simple routine became my joy and my will to live...");


    public static readonly Flower TulipaGesneriana = new(12, "Tulipa Gesneriana", 4, 1, 1, 3,
        "Once per session, at any time, you may roll 2d6. If your result is 2-4, gain 5 tension. From 5-9, your next Spell Card will cost 5 less tension. From 10-12, one opponent of your choosing cannot move on their next turn.",
        [
            0, 0, 0, 0, 0,
            0, 1, 1, 1, 0,
            0, 0, 2, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 0, 0, 0
        ],
        ["Perfect, True Love", "Royalty", "Cheerful Thoughts", "Forgiveness", "Sunshine", "Enchanting Simplicity"],
        "I can’t wait! The day where I will finally be at somebody’s side...");


    public static readonly Flower TagetesLucida = new(13, "Tagetes Lucida", 3, 3, 2, 1,
        "Once per session, you may flip a coin. On heads, you gain +2 to your next Danmaku attack. On tails, you gain +2 to your next Dodge. You may also use this skill to gain a +2 on Intimidation or Coercion, with Intimidation as heads and coercion as tails.",
        [
            0, 1, 1, 1, 0,
            0, 0, 0, 0, 0,
            0, 0, 2, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        ],
        ["Rising Sun", "Creativity", "Drive To Succeed", "Bravery", "Desire For Riches", "Honor Your Ancestors"],
        "Since I was a child, I was always told to never give up...");


    // ReSharper seems to be a little bit "confused" about this
    // ReSharper disable once CollectionNeverQueried.Global
    public static readonly List<Flower> Flowers =
    [
        RoteRosa,
        AmygdalusPersica,
        Lilium,
        PaeoniaSuffruticosa,
        HelianthusAnnuus,
        TrifoliumRepens,
        IrisSanguinea,
        MyosotisAlpestris,
        HibiscusSyriacus,
        HydrangeaMacrophylla,
        PogostemonCablin,
        TulipaGesneriana,
        TagetesLucida
    ];

    #endregion
}