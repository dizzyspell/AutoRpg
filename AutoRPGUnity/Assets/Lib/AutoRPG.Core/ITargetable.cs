namespace AutoRPG.Core;

/// <summary>
///     Something that can be the target of an <see cref="Actions.IAction" /> and its effects!
/// </summary>
public interface ITargetable
{
    /// <summary>
    ///     The user-presentable name of the target, which is mainly used for
    ///     creating a <see cref="Contexts.ActionContext" />
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Apply damage-type effect, aka health subtraction. This style of
    ///     effect will be going away soon, so im not gonna bother defining
    ///     all of these...
    /// </summary>
    /// <returns>the amount of damage that was actually done</returns>
    public int ApplyDamage(int aBaseDamage);

    /// <summary>
    ///     see docs for <see cref="ApplyDamage(int)" />
    /// </summary>
    public int ApplyDefense(int aBaseDefense);

    /// <summary>
    ///     see docs for <see cref="ApplyDamage(int)" />
    /// </summary>
    public int ApplyHeal(int aBaseHeal);

    /// <summary>
    ///     Simulate the application of the damage effect - <see cref="ApplyDamage(int)" />
    /// </summary>
    /// <returns>the amount of damage that would actually be done</returns>
    public int SimulateDamage(int aBaseDamage);

    /// <summary>
    ///     see docs for <see cref="SimulateDamage(int)" />
    /// </summary>
    public int SimulateDefense(int aBaseDefense);

    /// <summary>
    ///     see docs for <see cref="SimulateDamage(int)" />
    /// </summary>
    public int SimulateHeal(int aBaseHeal);
}