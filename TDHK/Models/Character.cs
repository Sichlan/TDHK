using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

    public Race Race
    {
        get => _race;
        set
        {
            if (Equals(value, _race))
                return;

            _race = value;
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
        }
    }

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

    public int Strength => StrengthBonus + (Race?.StrengthBonus).GetValueOrDefault() + (Flower?.StrengthBonus).GetValueOrDefault();
    public int Insight => InsightBonus + (Race?.InsightBonus).GetValueOrDefault() + (Flower?.InsightBonus).GetValueOrDefault();
    public int Intelligence => IntelligenceBonus + (Race?.IntelligenceBonus).GetValueOrDefault() + (Flower?.IntelligenceBonus).GetValueOrDefault();
    public int Charisma => CharismaBonus + (Race?.CharismaBonus).GetValueOrDefault() + (Flower?.CharismaBonus).GetValueOrDefault();

    public int Reflex =>
        Strength + Insight;

    public int Perception =>
        Insight + Intelligence;

    public int Style =>
        Intelligence + Charisma;

    public int Willpower =>
        Charisma + Strength;

    public int Danmaku =>
        GetAbilityValueFromShortName(DanmakuProperty);
    public int Dodge =>
        GetAbilityValueFromShortName(DodgeProperty) + Reflex / 2;

    public int Ability =>
        (GetAbilityValueFromShortName(AbilityProperty) + Style) / 2;

    public int Speed =>
        (Race?.MovementRange).GetValueOrDefault();

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


    public static readonly ReadOnlyCollection<string> CoreAbilities = new(new List<string>()
    {
        "",
        "STR",
        "INS",
        "INT",
        "CHA"
    });
}