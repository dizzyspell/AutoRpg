﻿using AutoRPG.Core.Actions;
using AutoRPG.Core.Classes;
using AutoRPG.Core.Contexts;
using AutoRPG.Core.Personalities;

namespace AutoRPG.Core;

/// <summary>
/// The main implementation of <see cref="ICharacter"/>.
/// </summary>
public class Character : ICharacter
{
    private readonly Guid mrId;
    private readonly string mrName;
    private readonly IClass mrClass;
    private readonly IPersonality mrPersonality;

    private ActionSet mrActionSet;
    private int mrMaxHealthPoints;
    private int mrCurrentHealthPoints;
    private int mrDefensePoints;
    private IContext mrContext;

    internal Character(string aName, IClass aClass, IPersonality aPersonality)
    {
        mrId = Guid.NewGuid();
        mrName = aName;
        mrClass = aClass;
        mrActionSet = mrClass.ActionSet;
        mrPersonality = aPersonality;
        mrMaxHealthPoints = 3;
        mrCurrentHealthPoints = mrMaxHealthPoints;
    }

    /// <summary>
    /// Randomly generates a new character! Optionally, with a specified name or 
    /// a random one.
    /// </summary>
    /// <param name="aName">Optional name to give the generated character. Leave empty for a random one.</param>
    /// <returns>A new character!</returns>
    public static ICharacter GenerateNew(string? aName = null)
    {
        string fName = aName ?? RandomNumberGod.ChooseName();
        IClass fClass = RandomNumberGod.ChooseClass();
        IPersonality fPersonality = RandomNumberGod.ChoosePersonality();

        return new Character(fName, fClass, fPersonality);
    }

    public Guid Id => mrId;

    public string Name => mrName;

    public IClass Class => mrClass;

    public IPersonality Personality => mrPersonality;

    public ActionSet ActionSet => mrActionSet;

    public int HealthPoints => mrCurrentHealthPoints;

    public int DefensePoints => mrDefensePoints;

    public bool IsAlive => mrCurrentHealthPoints > 0;

    public IContext Context
    {
        get => mrContext;
        set
        {
            mrContext = value;
            mrPersonality.Context = value;
        }
    }

    public string Summary => $"{Name}, the {Personality.Name} {Class.Name}";

    public string Details => $"{Name}\n{Personality.Name} {Class.Name}\n{ActionSet.Summary}";

    public int SimulateDamage(int aBaseDamage)
    {
        return Math.Clamp(aBaseDamage - mrDefensePoints, 0, mrCurrentHealthPoints);
    }

    public int ApplyDamage(int aBaseDamage)
    {
        int fAdjustedDamage = Math.Clamp(aBaseDamage - mrDefensePoints, 0, mrCurrentHealthPoints);
        mrCurrentHealthPoints -= fAdjustedDamage;
        mrDefensePoints = Math.Max(mrDefensePoints - aBaseDamage, 0);
        return fAdjustedDamage;
    }

    public int SimulateHeal(int aBaseHeal)
    {
        return Math.Min(aBaseHeal, mrMaxHealthPoints - mrCurrentHealthPoints);
    }

    public int ApplyHeal(int aBaseHeal)
    {
        int fMaxHeal = mrMaxHealthPoints - mrCurrentHealthPoints;
        int fAdjustedHeal = Math.Min(aBaseHeal, fMaxHeal);
        mrCurrentHealthPoints += fAdjustedHeal;
        return fAdjustedHeal;
    }

    public int SimulateDefense(int aBaseDefense)
    {
        return Math.Clamp(aBaseDefense, -mrDefensePoints, mrCurrentHealthPoints - mrDefensePoints);
    }

    public int ApplyDefense(int aBaseDefense)
    {
        int fAdjustedValue = Math.Clamp(aBaseDefense, -mrDefensePoints, mrCurrentHealthPoints - mrDefensePoints);
        mrDefensePoints += fAdjustedValue;
        return fAdjustedValue;
    }

    public ActionContext DoAnyAction()
    {
        return mrPersonality.DoAnyAction(mrActionSet);
    }

    public void ResetForRound()
    {
    }

    public override string ToString()
    {
        return $"{Name} ({Id})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is ICharacter fToCompare)
        {
            return fToCompare.Id.Equals(Id);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
