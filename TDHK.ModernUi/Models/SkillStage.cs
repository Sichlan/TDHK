using System.Collections.Generic;

namespace TDHK.ModernUi.Models;

public class SkillStage(
    int experienceCost,
    string effect,
    int? strengthRequirement = null,
    int? insightRequirement = null,
    int? intelligenceRequirement = null,
    int? charismaRequirement = null,
    int? reflexRequirement = null,
    int? perceptionRequirement = null,
    int? willpowerRequirement = null,
    int? styleRequirement = null,
    int[] raceIdRequirement = default)
{
    public int ExperienceCost { get; private init; } = experienceCost;
    public string Effect { get; private init; } = effect;
    public int? StrengthRequirement { get; private init; } = strengthRequirement;
    public int? InsightRequirement { get; private init; } = insightRequirement;
    public int? IntelligenceRequirement { get; private init; } = intelligenceRequirement;
    public int? CharismaRequirement { get; private init; } = charismaRequirement;
    public int? ReflexRequirement { get; private init; } = reflexRequirement;
    public int? PerceptionRequirement { get; private init; } = perceptionRequirement;
    public int? WillpowerRequirement { get; private init; } = willpowerRequirement;
    public int? StyleRequirement { get; private init; } = styleRequirement;
    public int[] RaceIdRequirement { get; private init; } = raceIdRequirement;
}