using ConsoleApp1.Actions;

namespace ConsoleApp1.Contexts;

internal class ActionContext : IContext
{
    public ActionContext(IContext aContext, IAction aExecuted, ITargetable aTarget, int aAdjustedValue)
    {
        Self = aContext.Self;
        Allies = aContext.Allies;
        Enemies = aContext.Enemies;

        Executed = aExecuted;
        Target = aTarget;
        AdjustedValue = aAdjustedValue;
    }

    public ICharacter Self { get; set; }

    public Party Allies { get; set; }

    public Party Enemies { get; set; }

    public IAction Executed { get; }

    public ITargetable Target { get; }

    public int AdjustedValue { get; }

    public override string ToString()
    {
        return $"{Self.Name} used {Executed.Name} on {Target.Name} for {AdjustedValue} points";
    }
}
