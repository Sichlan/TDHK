using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace TDHK.ModernUi.Models;

public class Character : ObservableObject
{
    private Race _race;
    private Flower _flower;
    private int _strengthBonus;
    private int _insightBonus;
    private int _intelligenceBonus;
    private int _charismaBonus;
    private string _name;
    private string _danmakuProperty;
    private string _dodgeProperty;
    private string _abilityProperty;
    private int _hitPoints;
    private int _experience = 15;
    private ObservableCollection<AbstractAdvancement> _advancements;

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
            // HitPoints = new Random().Next(1, MaxHitPoints);
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
            OnPropertyChanged(nameof(Speed));
            OnPropertyChanged(nameof(MaxHitPoints));
            OnPropertyChanged(nameof(Lives));
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
            OnPropertyChanged(nameof(Reflex));
            OnPropertyChanged(nameof(Willpower));
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
            OnPropertyChanged(nameof(Perception));
            OnPropertyChanged(nameof(Reflex));
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
            OnPropertyChanged(nameof(Perception));
            OnPropertyChanged(nameof(Style));
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
            OnPropertyChanged();
            OnPropertyChanged(nameof(Charisma));
            OnPropertyChanged(nameof(Style));
            OnPropertyChanged(nameof(Willpower));
            OnPropertyChanged(nameof(Danmaku));
            OnPropertyChanged(nameof(Dodge));
            OnPropertyChanged(nameof(Ability));
        }
    }

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
    public int Strength => StrengthBonus + (Race?.StrengthBonus).GetValueOrDefault() + (Flower?.StrengthBonus).GetValueOrDefault();
    [JsonIgnore]
    public int Insight => InsightBonus + (Race?.InsightBonus).GetValueOrDefault() + (Flower?.InsightBonus).GetValueOrDefault();
    [JsonIgnore]
    public int Intelligence => IntelligenceBonus + (Race?.IntelligenceBonus).GetValueOrDefault() + (Flower?.IntelligenceBonus).GetValueOrDefault();
    [JsonIgnore]
    public int Charisma => CharismaBonus + (Race?.CharismaBonus).GetValueOrDefault() + (Flower?.CharismaBonus).GetValueOrDefault();

    [JsonIgnore]
    public int Reflex => Strength + Insight;
    [JsonIgnore]
    public int Perception => Insight + Intelligence;
    [JsonIgnore]
    public int Style => Intelligence + Charisma;
    [JsonIgnore]
    public int Willpower => Charisma + Strength;

    [JsonIgnore]
    public int Danmaku => GetAbilityValueFromShortName(DanmakuProperty);
    [JsonIgnore]
    public int Dodge => GetAbilityValueFromShortName(DodgeProperty) + Reflex / 2;
    [JsonIgnore]
    public int Ability => (GetAbilityValueFromShortName(AbilityProperty) + Style) / 2;

    [JsonIgnore]
    public int Speed =>
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

    [JsonIgnore]
    public int MaxHitPoints => Race?.HitPoints ?? 0;

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
        => Advancements.Sum(x => x.Cost);

    [JsonIgnore]
    public bool HasUnspentExperience
        => Experience - Advancements.Sum(x => x.Cost) > 0;

    public ObservableCollection<AbstractAdvancement> Advancements
    {
        get => _advancements;
        init
        {
            if (Equals(value, _advancements))
                return;

            _advancements = value;
            _advancements.CollectionChanged += (_, _) =>
            {
                OnPropertyChanged(nameof(ExperienceSpent));
                OnPropertyChanged(nameof(HasUnspentExperience));
            };
            OnPropertyChanged();
            OnPropertyChanged(nameof(ExperienceSpent));
            OnPropertyChanged(nameof(HasUnspentExperience));
        }
    }

    public Character()
    {
        Advancements = new ObservableCollection<AbstractAdvancement>();
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