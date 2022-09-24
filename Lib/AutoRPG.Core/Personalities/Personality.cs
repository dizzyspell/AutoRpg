using AutoRPG.Core.Actions;
using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Personalities;

public abstract class Personality : IPersonality
{
    private readonly string mrName;
    private readonly int mrBasicChance;
    private readonly int mrSupportChance;
    private readonly int mrDefendChance;
    private readonly int mrAttackChance;
    private readonly int mrTotalChance;

    protected Personality(string aName, int aBasicChance, int aSupportChance, int aDefendChance, int aAttackChance)
    {
        mrName = aName;
        mrBasicChance = aBasicChance;
        mrSupportChance = aSupportChance;
        mrDefendChance = aDefendChance;
        mrAttackChance = aAttackChance;
        mrTotalChance = aBasicChance + aSupportChance + aDefendChance + aAttackChance;
    }

    public string Name => mrName;

    public IContext Context { get; set; }

    protected IAction ChooseAction(ActionSet aActionSet)
    {
        List<Tuple<IAction, int>> fChanceSet = new List<Tuple<IAction, int>>
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

    protected ITargetable? ChooseTarget(IAction aAction)
    {
        IEnumerable<ITargetable> fValidTargets = aAction.ValidTargets(Context);
        return fValidTargets.FirstOrDefault();
    }

    public ActionContext DoAnyAction(ActionSet aActionSet)
    {
        IAction fChosenAction;
        ITargetable? fChosenTarget = null;

        do
        {
            fChosenAction = ChooseAction(aActionSet);
            fChosenTarget = ChooseTarget(fChosenAction);
        } while (fChosenTarget == null);

        return fChosenAction.Execute(Context, fChosenTarget);
    }
}
