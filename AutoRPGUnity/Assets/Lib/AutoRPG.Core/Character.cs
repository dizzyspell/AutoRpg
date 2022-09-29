using AutoRPG.Core.Actions;
using AutoRPG.Core.Classes;
using AutoRPG.Core.Contexts;
using AutoRPG.Core.Extensions;
using AutoRPG.Core.Personalities;

namespace AutoRPG.Core;

/// <summary>
///     The main implementation of <see cref="ICharacter" />.
/// </summary>
public class Character : ICharacter
{
    private readonly int mrMaxHealthPoints;

    private IContext mContext;

    internal Character(string aName, IClass aClass, IPersonality aPersonality)
    {
        Id                = Guid.NewGuid();
        Name              = aName;
        Class             = aClass;
        ActionSet         = Class.ActionSet;
        Personality       = aPersonality;
        mrMaxHealthPoints = 3;
        HealthPoints      = mrMaxHealthPoints;
    }

    public Guid Id { get; }

    public string Name { get; }

    public IClass Class { get; }

    public IPersonality Personality { get; }

    public ActionSet ActionSet { get; }

    public int HealthPoints { get; private set; }

    public int DefensePoints { get; private set; }

    public bool IsAlive => HealthPoints > 0;

    public IContext Context
    {
        get => mContext;
        set
        {
            mContext            = value;
            Personality.Context = value;
        }
    }

    public string Summary => $"{Name}, the {Personality.Name} {Class.Name}";

    public string Details =>
        $"{Name}\n{Personality.Name} {Class.Name}\n{ActionSet.Summary}";

    public int SimulateDamage(int aBaseDamage)
    {
        return (aBaseDamage - DefensePoints).Clamp(0, HealthPoints);
    }

    public int ApplyDamage(int aBaseDamage)
    {
        int fAdjustedDamage =
            (aBaseDamage - DefensePoints).Clamp(0, HealthPoints);
        HealthPoints  -= fAdjustedDamage;
        DefensePoints =  Math.Max(DefensePoints - aBaseDamage, 0);
        return fAdjustedDamage;
    }

    public int SimulateHeal(int aBaseHeal)
    {
        return Math.Min(aBaseHeal, mrMaxHealthPoints - HealthPoints);
    }

    public int ApplyHeal(int aBaseHeal)
    {
        int fMaxHeal      = mrMaxHealthPoints - HealthPoints;
        int fAdjustedHeal = Math.Min(aBaseHeal, fMaxHeal);
        HealthPoints += fAdjustedHeal;
        return fAdjustedHeal;
    }

    public int SimulateDefense(int aBaseDefense)
    {
        return aBaseDefense.Clamp(-DefensePoints, HealthPoints - DefensePoints);
    }

    public int ApplyDefense(int aBaseDefense)
    {
        int fAdjustedValue = aBaseDefense.Clamp(
            -DefensePoints, HealthPoints - DefensePoints);
        DefensePoints += fAdjustedValue;
        return fAdjustedValue;
    }

    public ActionContext DoAnyAction()
    {
        return Personality.DoAnyAction(ActionSet);
    }

    public void ResetForRound()
    {
    }

    /// <summary>
    ///     Randomly generates a new character! Optionally, with a specified name or
    ///     a random one.
    /// </summary>
    /// <param name="aName">Optional name to give the generated character. Leave empty for a random one.</param>
    /// <returns>A new character!</returns>
    public static ICharacter GenerateNew(string? aName = null)
    {
        string       fName        = aName ?? RandomNumberGod.ChooseName();
        IClass       fClass       = RandomNumberGod.ChooseClass();
        IPersonality fPersonality = RandomNumberGod.ChoosePersonality();

        return new Character(fName, fClass, fPersonality);
    }

    public override string ToString()
    {
        return $"{Name} ({Id})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is ICharacter fToCompare) return fToCompare.Id.Equals(Id);

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}