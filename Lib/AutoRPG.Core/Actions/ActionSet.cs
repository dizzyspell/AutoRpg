namespace AutoRPG.Core.Actions;

/// <summary>
/// A standardized set of <see cref="IAction"/>s, currently one of each <see cref="ActionType"/>
/// </summary>
public class ActionSet
{
    private readonly IAction mrBasic;
    private readonly IAction mrSupport;
    private readonly IAction mrDefend;
    private readonly IAction mrAttack;

    internal ActionSet(IAction aBasic, IAction aSupport, IAction aDefend, IAction aAttack)
    {
        mrBasic = VerifyActionType(aBasic, ActionType.Basic);
        mrSupport = VerifyActionType(aSupport, ActionType.Support);
        mrDefend = VerifyActionType(aDefend, ActionType.Defend);
        mrAttack = VerifyActionType(aAttack, ActionType.Attack);
    }

    /// <summary>
    /// Verify that an action's type matches the one we're expecting.
    /// </summary>
    /// <param name="aActionToCheck">The action who's type we're checking, obvs</param>
    /// <param name="aTypeItShouldBe">The type of action it should be, obvs</param>
    /// <returns>The action we were checking, if it is of the expected type. Otherwise, this method throws an exception.</returns>
    /// <exception cref="ArgumentException"/>
    private IAction VerifyActionType(IAction aActionToCheck, ActionType aTypeItShouldBe)
    {
        if (aActionToCheck.Type != aTypeItShouldBe)
        {
            throw new ArgumentException($"Action {aActionToCheck} was supposed to be {aTypeItShouldBe} - instead it was {aActionToCheck.Type}");
        }
        return aActionToCheck;
    }

    public IAction Basic => mrBasic;

    public IAction Support => mrSupport;

    public IAction Defend => mrDefend;

    public IAction Attack => mrAttack;

    /// <summary>
    /// User-presentable representation of the action set, names only. Mainly
    /// for the console app.
    /// </summary>
    public string Summary => "\n> " + string.Join("\n> ", Basic.Name, Support.Name, Defend.Name, Attack.Name);
}
