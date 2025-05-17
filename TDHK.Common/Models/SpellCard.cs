namespace TDHK.Common.Models;

public enum SpellCardTiming
{
    Action,
    Reaction
}

public class SpellCard : ObservableObject
{
    private string _name;
    private int[] _attackRange;
    private SpellCardTiming _spellCardTiming;

    public string Name
    {
        get => _name;
        set
        {
            if (value == _name)
                return;

            _name = value;
            OnPropertyChanged();
        }
    }

    public int[] AttackRange
    {
        get => _attackRange;
        set
        {
            if (Equals(value, _attackRange))
                return;

            _attackRange = value;
            OnPropertyChanged();
        }
    }

    public SpellCardTiming SpellCardTiming
    {
        get => _spellCardTiming;
        set
        {
            if (value == _spellCardTiming)
                return;

            _spellCardTiming = value;
            OnPropertyChanged();
        }
    }

    public int Cost { get; set; }
    public int Duration { get; set; }
    public int Targets { get; set; }
    public int Modifier { get; set; }
    public int Dice { get; set; }
    public string Description { get; set; }

    public SpellCard()
    {
        AttackRange = new int[7 * 7];
    }
}