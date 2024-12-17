namespace TDHK.ModernUi.Models;

public class HitPointSection
{
    public int SectionValue { get; set; }
    public int SectionMax { get; set; }
    public int SectionSize { get; set; }

    public HitPointSection(int sectionValue, int sectionMax, int sectionSize) : this()
    {
        SectionValue = sectionValue;
        SectionMax = sectionMax;
        SectionSize = sectionSize;
    }

    // Default constructor to use for UI Designer
    public HitPointSection()
    { }
}