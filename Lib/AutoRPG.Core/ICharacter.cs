using AutoRPG.Core.Actions;
using AutoRPG.Core.Classes;
using AutoRPG.Core.Contexts;
using AutoRPG.Core.Personalities;

namespace AutoRPG.Core;

public interface ICharacter : ITargetable
{
    public Guid Id { get; }
    public IClass Class { get; }
    public IPersonality Personality { get; }
    public ActionSet ActionSet { get; }
    public int HealthPoints { get; }
    public int DefensePoints { get; }
    public bool IsAlive { get; }
    public string Summary { get; }
    public IContext Context { get; set; }

    public ActionContext DoAnyAction();
    public void ResetForRound();
}
