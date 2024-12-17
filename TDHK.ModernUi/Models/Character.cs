using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace TDHK.ModernUi.Models;

public enum AbilityCategory
{
    Execution = 4,
    Creation = 6,
    Manipulation = 8
}

public enum AbilityTarget
{
    Individual = 2,
    Group = 4,
    Area = 6,
    Mass = 10
}

public enum AbilityRange
{
    Contact = 1,
    Seen = 2,
    Known = 6,
    Unknown = 10
}

public class Character : ObservableObject
{
    private Race _race;
    private Flower _flower;
    private string _name;
    private string _danmakuProperty;
    private string _dodgeProperty;
    private string _abilityProperty;
    private int _hitPoints;
    private int _experience = 15;
    private string _abilityDescription;
    private AbilityCategory _abilityCategory;
    private AbilityTarget _abilityTarget;
    private AbilityRange _abilityRange;
    private int _strengthBonus;
    private int _insightBonus;
    private int _intelligenceBonus;
    private int _charismaBonus;
    private int _maxHitPointBonus;
    private int _reflexBonus;
    private int _perceptionBonus;
    private int _styleBonus;
    private int _willpowerBonus;
    private int _spellCardSlots = 2;
    private int _abilityTargetNumberDiscount;

    public string Name
    {
        get => _name;
        set
        {
            if (value == _name)
                return;

            _name = value;
            OnPropertyChanged();
            OnPropertyChanged();
        }
    }

    public int? RaceId
    {
        get => Race?.Id;
        set => Race = Race.Races.FirstOrDefault(x => x.Id == value);
    }

    [JsonIgnore]
    public Race Race
    {
        get => _race;
        set
        {
            if (Equals(value, _race))
                return;

            _race = value;
            HitPoints = MaxHitPoints;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Strength));
            OnPropertyChanged(nameof(Insight));
            OnPropertyChanged(nameof(Intelligence));
            OnPropertyChanged(nameof(Charisma));
            OnPropertyChanged(nameof(Reflex));
            OnPropertyChanged(nameof(Perception));
            OnPropertyChanged(nameof(Willpower));
            OnPropertyChanged(nameof(Style));
            OnPropertyChanged(nameof(Danmaku));
            OnPropertyChanged(nameof(Dodge));
            OnPropertyChanged(nameof(Ability));
            OnPropertyChanged(nameof(Movement));
            OnPropertyChanged(nameof(MaxHitPoints));
        }
    }

    public int? FlowerId
    {
        get => Flower?.Id;
        set => Flower = Flower.Flowers.FirstOrDefault(x => x.Id == value);
    }

    [JsonIgnore]
    public Flower Flower
    {
        get => _flower;
        set
        {
            if (Equals(value, _flower))
                return;

            _flower = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Strength));
            OnPropertyChanged(nameof(Insight));
            OnPropertyChanged(nameof(Intelligence));
            OnPropertyChanged(nameof(Charisma));
            OnPropertyChanged(nameof(Reflex));
            OnPropertyChanged(nameof(Perception));
            OnPropertyChanged(nameof(Willpower));
            OnPropertyChanged(nameof(Style));
            OnPropertyChanged(nameof(Danmaku));
            OnPropertyChanged(nameof(Dodge));
            OnPropertyChanged(nameof(Ability));
        }
    }

    #region Core Stats

    public int StrengthBonus
    {
        get => _strengthBonus;
        set
        {
            if (value == _strengthBonus)
                return;

            _strengthBonus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Strength));
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
            OnPropertyChanged(nameof(Danmaku));
            OnPropertyChanged(nameof(Dodge));
            OnPropertyChanged(nameof(Ability));
        }
    }

    public int InsightBonus
    {
        get => _insightBonus;
        set
        {
            if (value == _insightBonus)
                return;

            _insightBonus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Insight));
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
            OnPropertyChanged(nameof(Danmaku));
            OnPropertyChanged(nameof(Dodge));
            OnPropertyChanged(nameof(Ability));
        }
    }

    public int IntelligenceBonus
    {
        get => _intelligenceBonus;
        set
        {
            if (value == _intelligenceBonus)
                return;

            _intelligenceBonus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Intelligence));
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
            OnPropertyChanged(nameof(Danmaku));
            OnPropertyChanged(nameof(Dodge));
            OnPropertyChanged(nameof(Ability));
        }
    }

    public int CharismaBonus
    {
        get => _charismaBonus;
        set
        {
            if (value == _charismaBonus)
                return;

            _charismaBonus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Charisma));
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
            OnPropertyChanged(nameof(Danmaku));
            OnPropertyChanged(nameof(Dodge));
            OnPropertyChanged(nameof(Ability));
        }
    }

    [JsonIgnore]
    public int Strength => StrengthBonus + (Race?.StrengthBonus).GetValueOrDefault() + (Flower?.StrengthBonus).GetValueOrDefault();
    [JsonIgnore]
    public int Insight => InsightBonus + (Race?.InsightBonus).GetValueOrDefault() + (Flower?.InsightBonus).GetValueOrDefault();
    [JsonIgnore]
    public int Intelligence => IntelligenceBonus + (Race?.IntelligenceBonus).GetValueOrDefault() + (Flower?.IntelligenceBonus).GetValueOrDefault();
    [JsonIgnore]
    public int Charisma => CharismaBonus + (Race?.CharismaBonus).GetValueOrDefault() + (Flower?.CharismaBonus).GetValueOrDefault();

    #endregion

    #region Sub Stats

    public int ReflexBonus
    {
        get => _reflexBonus;
        set
        {
            if (value == _reflexBonus)
                return;

            _reflexBonus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Reflex));
            OnPropertyChanged(nameof(Dodge));
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
        }
    }

    public int PerceptionBonus
    {
        get => _perceptionBonus;
        set
        {
            if (value == _perceptionBonus)
                return;

            _perceptionBonus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Perception));
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
        }
    }

    public int StyleBonus
    {
        get => _styleBonus;
        set
        {
            if (value == _styleBonus)
                return;

            _styleBonus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Style));
            OnPropertyChanged(nameof(Ability));
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
        }
    }

    public int WillpowerBonus
    {
        get => _willpowerBonus;
        set
        {
            if (value == _willpowerBonus)
                return;

            _willpowerBonus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Willpower));
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
        }
    }

    [JsonIgnore] public int Reflex => Strength + Insight + ReflexBonus;
    [JsonIgnore] public int Perception => Insight + Intelligence + PerceptionBonus;
    [JsonIgnore] public int Style => Intelligence + Charisma + StyleBonus;
    [JsonIgnore] public int Willpower => Charisma + Strength + WillpowerBonus;

    #endregion

    public string DanmakuProperty
    {
        get => _danmakuProperty;
        set
        {
            if (value == _danmakuProperty)
                return;

            _danmakuProperty = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Danmaku));
        }
    }

    public string DodgeProperty
    {
        get => _dodgeProperty;
        set
        {
            if (value == _dodgeProperty)
                return;

            _dodgeProperty = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Dodge));
        }
    }

    public string AbilityProperty
    {
        get => _abilityProperty;
        set
        {
            if (value == _abilityProperty)
                return;

            _abilityProperty = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Ability));
        }
    }

    [JsonIgnore]
    public int Danmaku => GetAbilityValueFromShortName(DanmakuProperty);
    [JsonIgnore]
    public int Dodge => (GetAbilityValueFromShortName(DodgeProperty) + Reflex) / 2 + (Race == Race.Inchling ? 1 : 0);
    [JsonIgnore]
    public int Ability => (GetAbilityValueFromShortName(AbilityProperty) + Style) / 2;

    [JsonIgnore]
    public int Movement =>
        (Race?.MovementRange).GetValueOrDefault();

    public int HitPoints
    {
        get => _hitPoints;
        set
        {
            if (value == _hitPoints)
                return;

            _hitPoints = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Lives));
        }
    }

    public int MaxHitPointBonus
    {
        get => _maxHitPointBonus;
        set
        {
            if (value == _maxHitPointBonus)
                return;

            _maxHitPointBonus = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Lives));
            OnPropertyChanged(nameof(MaxHitPoints));
            OnPropertyChanged(nameof(ExperienceSpent));
        }
    }

    [JsonIgnore]
    public int MaxHitPoints => (Race?.HitPoints ?? 0) + MaxHitPointBonus;

    [JsonIgnore]
    public List<HitPointSection> Lives {
        get
        {
            if (Race == null)
                return null;

            var hp = HitPoints;
            var maxHp = MaxHitPoints;
            var lives = new List<HitPointSection>();
            var sectionSize = Race == Race.HumanHourai ? 20 : 10;

            while (maxHp > 0)
            {
                var hpSection = Math.Min(hp, sectionSize);
                var maxHpSection = Math.Min(maxHp, sectionSize);
                hp -= hpSection;
                maxHp -= maxHpSection;

                lives.Add(new HitPointSection(hpSection, maxHpSection, sectionSize));
            }

            return lives;
        }
    }

    public int Experience
    {
        get => _experience;
        set
        {
            if (value == _experience)
                return;

            _experience = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasUnspentExperience));
        }
    }

    [JsonIgnore]
    public int ExperienceSpent
        => MaxHitPointBonus * 2
           + (StrengthBonus + IntelligenceBonus + InsightBonus + CharismaBonus) * 7
           + (ReflexBonus + PerceptionBonus + WillpowerBonus + StyleBonus) * 5
           + (SpellCardSlots - 2 + AbilityTargetNumberDiscount) * 3;

    [JsonIgnore]
    public bool HasUnspentExperience
        => Experience > ExperienceSpent;

    public string AbilityDescription
    {
        get => _abilityDescription;
        set
        {
            if (value == _abilityDescription)
                return;

            _abilityDescription = value;
            OnPropertyChanged();
        }
    }

    public AbilityCategory AbilityCategory
    {
        get => _abilityCategory;
        set
        {
            if (value == _abilityCategory)
                return;

            _abilityCategory = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(AbilityTargetNumber));
        }
    }

    public AbilityTarget AbilityTarget
    {
        get => _abilityTarget;
        set
        {
            if (value == _abilityTarget)
                return;

            _abilityTarget = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(AbilityTargetNumber));
        }
    }

    public AbilityRange AbilityRange
    {
        get => _abilityRange;
        set
        {
            if (value == _abilityRange)
                return;

            _abilityRange = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(AbilityTargetNumber));
        }
    }

    public int AbilityTargetNumber => (int)AbilityCategory + (int)AbilityTarget + (int)AbilityRange - AbilityTargetNumberDiscount;

    public int SpellCardSlots
    {
        get => _spellCardSlots;
        set
        {
            if (value == _spellCardSlots)
                return;

            _spellCardSlots = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
        }
    }

    public int AbilityTargetNumberDiscount
    {
        get => _abilityTargetNumberDiscount;
        set
        {
            if (value == _abilityTargetNumberDiscount)
                return;

            _abilityTargetNumberDiscount = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(AbilityTargetNumber));
            OnPropertyChanged(nameof(HasUnspentExperience));
        }
    }

    public int GetAbilityValueFromShortName(string ability)
    {
        return ability switch
        {
            "STR" => Strength,
            "INS" => Insight,
            "INT" => Intelligence,
            "CHA" => Charisma,
            "REF" => Reflex,
            "WIL" => Willpower,
            "STL" => Style,
            "" => 0,
            null => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(ability))
        };
    }


    // ReSharper disable once CollectionNeverQueried.Global
    public static readonly ReadOnlyCollection<string> CoreAbilities = new(new List<string>()
    {
        "",
        "STR",
        "INS",
        "INT",
        "CHA"
    });
}