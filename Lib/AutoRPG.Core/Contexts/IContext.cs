namespace AutoRPG.Core.Contexts;

/// <summary>
/// Describes the current context that an <see cref="ICharacter"/> is in.
/// </summary>
public interface IContext
{
    /// <summary>
    /// "Who am I?"
    /// Each context is from the perspective of a particular entity - so this
    /// property represents that entity!
    /// </summary>
    public ICharacter Self { get; set; }

    /// <summary>
    /// "Who's on my side?"
    /// Usually, the <see cref="Party"/> that <see cref="Self"/> is a part of.
    /// </summary>
    public Party Allies { get; set; }

    /// <summary>
    /// "Who's not on my side?"
    /// Usually, the other <see cref="Party"/> in a battle or some such.
    /// </summary>
    public Party Enemies { get; set; }
}
