namespace AutoRPG.Core.Contexts;

public interface IContext
{
    public ICharacter Self { get; set; }

    public Party Allies { get; set; }

    public Party Enemies { get; set; }
}
