using System;

namespace TDHK.ModernUi.Models;

[Flags]
public enum SkillType
{
    None = 0,
    General = 1 << 0,
    Combat = 1 << 1,
    Incident = 1 << 2
}