using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using DynamicData.Binding;

namespace TDHK.Common.Models;

public partial class Character : ObservableValidator
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(RaceId),nameof(Strength),nameof(Insight),nameof(Intelligence),nameof(Charisma),nameof(Reflex),nameof(Perception),nameof(Willpower),nameof(Style),nameof(Danmaku),nameof(Dodge),nameof(Ability),nameof(Movement),nameof(MaxHitPoints))]
    [Required]
    [property: JsonIgnore]
    private Race? _race;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FlowerId),nameof(Strength),nameof(Insight),nameof(Intelligence),nameof(Charisma),nameof(Reflex),nameof(Perception),nameof(Willpower),nameof(Style),nameof(Danmaku),nameof(Dodge),nameof(Ability))]
    [property: JsonIgnore]
    [Required]
    private Flower? _flower;

    [ObservableProperty]
    [Required]
    private string _name;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Danmaku))]
    [Required]
    private string _danmakuProperty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Dodge))]
    [Required]
    private string _dodgeProperty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Ability))]
    [Required]
    private string _abilityProperty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Lives))]
    private int _hitPoints;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Lives), nameof(MaxHitPoints), nameof(ExperienceSpent), nameof(HasUnspentExperience))]
    private int _maxHitPointBonus;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasUnspentExperience))]
    private int _experience = 15;

    [ObservableProperty]
    [Required]
    private string _abilityDescription;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AbilityTargetNumber))]
    [Required]
    private AbilityCategory? _abilityCategory;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AbilityTargetNumber))]
    [Required]
    private AbilityTarget? _abilityTarget;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AbilityTargetNumber))]
    [Required]
    private AbilityRange? _abilityRange;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Strength), nameof(ExperienceSpent), nameof(HasUnspentExperience), nameof(Danmaku), nameof(Dodge), nameof(Ability))]
    private int _strengthBonus;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Insight), nameof(ExperienceSpent), nameof(HasUnspentExperience), nameof(Danmaku), nameof(Dodge), nameof(Ability))]
    private int _insightBonus;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Intelligence), nameof(ExperienceSpent), nameof(HasUnspentExperience), nameof(Danmaku), nameof(Dodge), nameof(Ability))]
    private int _intelligenceBonus;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Charisma), nameof(ExperienceSpent), nameof(HasUnspentExperience), nameof(Danmaku), nameof(Dodge), nameof(Ability))]
    private int _charismaBonus;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Reflex), nameof(ExperienceSpent), nameof(HasUnspentExperience), nameof(Danmaku), nameof(Dodge), nameof(Ability))]
    private int _reflexBonus;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Perception), nameof(ExperienceSpent), nameof(HasUnspentExperience), nameof(Danmaku), nameof(Dodge), nameof(Ability))]
    private int _perceptionBonus;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Style), nameof(ExperienceSpent), nameof(HasUnspentExperience), nameof(Danmaku), nameof(Dodge), nameof(Ability))]
    private int _styleBonus;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Willpower), nameof(ExperienceSpent), nameof(HasUnspentExperience), nameof(Danmaku), nameof(Dodge), nameof(Ability))]
    private int _willpowerBonus;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ExperienceSpent), nameof(HasUnspentExperience))]
    private int _spellCardSlots = 2;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ExperienceSpent), nameof(AbilityTargetNumber), nameof(HasUnspentExperience))]
    private int _abilityTargetNumberDiscount;

    [ObservableProperty]
    private bool _isPlayMode;

    [ObservableProperty]
    private ObservableCollection<SpellCard> _spellCards;

    public int? RaceId
    {
        get => Race?.Id;
        set => Race = Race.Races.FirstOrDefault(x => x.Id == value);
    }

    public int? FlowerId
    {
        get => Flower?.Id;
        set => Flower = Flower.Flowers.FirstOrDefault(x => x.Id == value);
    }

    #region Core Stats

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

    [JsonIgnore]
    public int Reflex => Strength + Insight + ReflexBonus;
    [JsonIgnore]
    public int Perception => Insight + Intelligence + PerceptionBonus;
    [JsonIgnore]
    public int Style => Intelligence + Charisma + StyleBonus;
    [JsonIgnore]
    public int Willpower => Charisma + Strength + WillpowerBonus;

    #endregion

    #region Derived Stats

    [JsonIgnore]
    public int Danmaku => GetAbilityValueFromShortName(DanmakuProperty);
    [JsonIgnore]
    public int Dodge => (GetAbilityValueFromShortName(DodgeProperty) + Reflex) / 2 + (Race == Race.Inchling ? 1 : 0);
    [JsonIgnore]
    public int Ability => (GetAbilityValueFromShortName(AbilityProperty) + Style) / 2;

    #endregion

    [JsonIgnore]
    public int Movement => (Race?.MovementRange).GetValueOrDefault();

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

    [JsonIgnore]
    public int ExperienceSpent => MaxHitPointBonus * 2
                                  + (StrengthBonus + IntelligenceBonus + InsightBonus + CharismaBonus) * 7
                                  + (ReflexBonus + PerceptionBonus + WillpowerBonus + StyleBonus) * 5
                                  + (Math.Max(SpellCardSlots - 2, 0) + AbilityTargetNumberDiscount) * 3;

    [JsonIgnore]
    public bool HasUnspentExperience => Experience > ExperienceSpent;

    [JsonIgnore]
    public int AbilityTargetNumber => ((int?)AbilityCategory ?? 0) + ((int?)AbilityTarget ?? 0) + ((int?)AbilityRange ?? 0) - AbilityTargetNumberDiscount;

    [ObservableProperty]
    [property: JsonIgnore]
    private ObservableCollection<string> _danmakuProperties;

    [ObservableProperty]
    [property: JsonIgnore]
    private ObservableCollection<string> _dodgeProperties;

    [ObservableProperty]
    [property: JsonIgnore]
    private ObservableCollection<string> _abilityProperties;

    public Character()
    {
        SpellCards = [];

        // oh yeah
        this.WhenAnyPropertyChanged(nameof(DodgeProperty), nameof(AbilityProperty)).Subscribe(x => { DanmakuProperties = new ObservableCollection<string>(CoreAbilities.Where(s => s == "" || (s != DodgeProperty && s != AbilityProperty))); });
        this.WhenAnyPropertyChanged(nameof(DanmakuProperty), nameof(AbilityProperty)).Subscribe(x => { DodgeProperties = new ObservableCollection<string>(CoreAbilities.Where(s => s == "" || (s != DanmakuProperty && s != AbilityProperty))); });
        this.WhenAnyPropertyChanged(nameof(DanmakuProperty), nameof(DodgeProperty)).Subscribe(x => { AbilityProperties = new ObservableCollection<string>(CoreAbilities.Where(s => s == "" || (s != DanmakuProperty && s != DodgeProperty))); });

        DanmakuProperties = new ObservableCollection<string>(CoreAbilities.Where(s => s == "" || (s != DodgeProperty && s != AbilityProperty)));
        DodgeProperties = new ObservableCollection<string>(CoreAbilities.Where(s => s == "" || (s != DanmakuProperty && s != AbilityProperty)));
        AbilityProperties = new ObservableCollection<string>(CoreAbilities.Where(s => s == "" || (s != DanmakuProperty && s != DodgeProperty)));
    }

    [RelayCommand(CanExecute = nameof(CanFinishCharacterCreation))]
    [property: JsonIgnore]
    private void FinishCharacterCreation()
    {
        IsPlayMode = true;
    }

    private bool CanFinishCharacterCreation()
    {
        return !HasErrors;
    }

    partial void OnRaceChanged(Race value)
    {
        HitPoints = MaxHitPoints;
    }

    private int GetAbilityValueFromShortName(string ability)
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
            "" or null => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(ability))
        };
    }


    // ReSharper disable once CollectionNeverQueried.Global
    public static readonly ObservableCollectionExtended<string> CoreAbilities =
    [
        "",
        "STR",
        "INS",
        "INT",
        "CHA"
    ];
}