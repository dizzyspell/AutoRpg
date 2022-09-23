using ConsoleApp1.Actions;
using ConsoleApp1.Classes;
using ConsoleApp1.Contexts;
using ConsoleApp1.Personalities;

namespace ConsoleApp1;

internal class Character : ICharacter
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

    public Character(string aName, IClass aClass, IPersonality aPersonality)
    {
        mrId = Guid.NewGuid();
        mrName = aName;
        mrClass = aClass;
        mrActionSet = mrClass.ActionSet;
        mrPersonality = aPersonality;
        mrMaxHealthPoints = 3;
        mrCurrentHealthPoints = mrMaxHealthPoints;
    }
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

    public IContext Context { 
        get => mrContext; 
        set { 
            mrContext = value;
            mrPersonality.Context = value;
        }
    }

    public string Summary => $"{Name}, the {Personality} {Class}";

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
        int fAdjustedValue = Math.Clamp(aBaseDefense, -mrDefensePoints, mrCurrentHealthPoints-mrDefensePoints);
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
        return $"{Name}\n{Personality} {Class}\n{ActionSet}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is ICharacter fToCompare)
        {
            return fToCompare.Id.Equals(this.Id);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}
