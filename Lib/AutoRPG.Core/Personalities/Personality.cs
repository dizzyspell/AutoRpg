using AutoRPG.Core.Actions;
using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Personalities;

/// <summary>
///     A base class with default functionality for simple personalities. Makes
///     decisions about actions using chance and randomness. Abstract, so it can
///     never be directly instantiated.
/// </summary>
public abstract class Personality : IPersonality
{
    private readonly int mrAttackChance;
    private readonly int mrBasicChance;
    private readonly int mrDefendChance;
    private readonly int mrSupportChance;
    private readonly int mrTotalChance;

    /// <summary>
    ///     Set up a new personality, with the given name and chances to execute each
    ///     action type. The chances for each action type are represented like a ratio,
    ///     like 2:1:1:1. If you want the Basic action to be on a 50% chance, for example,
    ///     then the int representing that chance should be the sum of all the other
    ///     chances - like 3:1:1:1 or 5:1:2:2 or whatevs.
    /// </summary>
    /// <param name="aName">User-presentable name of the personality</param>
    protected Personality(
        string aName, int aBasicChance, int aSupportChance, int aDefendChance,
        int    aAttackChance)
    {
        Name            = aName;
        mrBasicChance   = aBasicChance;
        mrSupportChance = aSupportChance;
        mrDefendChance  = aDefendChance;
        mrAttackChance  = aAttackChance;
        mrTotalChance = aBasicChance + aSupportChance + aDefendChance +
                        aAttackChance;
    }

    public string Name { get; }

    public IContext Context { get; set; }

    public ActionContext DoAnyAction(ActionSet aActionSet)
    {
        IAction      fChosenAction;
        ITargetable? fChosenTarget = null;

        do
        {
            fChosenAction = ChooseAction(aActionSet);
            fChosenTarget = ChooseTarget(fChosenAction);
        } while (fChosenTarget == null);

        return fChosenAction.Execute(Context, fChosenTarget);
    }

    /// <summary>
    ///     Choose an action from the available set to do. In the base class, this
    ///     is random based on the chances provided at construction. Please override
    ///     this with something more interesting... or make a new base class!
    /// </summary>
    /// <param name="aActionSet">The list of actions to choose from</param>
    /// <returns>The action from the provided set which was chosen</returns>
    protected IAction ChooseAction(ActionSet aActionSet)
    {
        List<Tuple<IAction, int>> fChanceSet = new()
        {
            new(aActionSet.Basic, mrBasicChance),
            new(aActionSet.Support, mrSupportChance),
            new(aActionSet.Defend, mrDefendChance),
            new(aActionSet.Attack, mrAttackChance)
        };

        int fRandInt = RandomNumberGod.ChooseInt(mrTotalChance);

        IAction fChosenAction = null;

        foreach (Tuple<IAction, int> _action in fChanceSet)
        {
            if (fRandInt < _action.Item2)
            {
                fChosenAction = _action.Item1;
                break;
            }

            fRandInt -= _action.Item2;
        }

        return fChosenAction;
    }

    /// <summary>
    ///     Choose a target for a given action from the current context. In the base
    ///     class, this just chooses the first valid target. Please override
    ///     this with something more interesting... or make a new base class!
    /// </summary>
    /// <param name="aAction">The action which we're finding a good target for.</param>
    /// <returns>
    ///     The chosen target, if there is one. null, if there were no valid targets
    ///     for the action or if we didn't like any of the ones available.
    /// </returns>
    protected ITargetable? ChooseTarget(IAction aAction)
    {
        IEnumerable<ITargetable> fValidTargets = aAction.ValidTargets(Context);
        return fValidTargets.FirstOrDefault();
    }
}