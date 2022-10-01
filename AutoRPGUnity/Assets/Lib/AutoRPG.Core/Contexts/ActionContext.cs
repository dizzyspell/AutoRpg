using AutoRPG.Core.Actions;

namespace AutoRPG.Core.Contexts
{
    /// <summary>
    ///     An <see cref="IContext" /> which describes the execution and outcome of an <see cref="IAction" />.
    /// </summary>
    public class ActionContext : IContext
    {
        /// <summary>
        ///     Create a new <see cref="ActionContext" />.
        /// </summary>
        /// <param name="aContext">The context the action occurred in, from which some properties will be auto-filled</param>
        /// <param name="aExecuted">The action which was executed</param>
        /// <param name="aTarget">The target for the main effect(s) of the action</param>
        /// <param name="aAdjustedValue">
        ///     The actual value of the effect that was applied, after taking into account resistances
        ///     and/or other effects
        /// </param>
        internal ActionContext(
            IContext aContext, IAction aExecuted, ITargetable aTarget,
            int aAdjustedValue)
        {
            Self    = aContext.Self;
            Allies  = aContext.Allies;
            Enemies = aContext.Enemies;

            Executed      = aExecuted;
            Target        = aTarget;
            AdjustedValue = aAdjustedValue;
        }

        /// <summary>
        ///     The action which was executed.
        /// </summary>
        public IAction Executed { get; }

        /// <summary>
        ///     The target for the main effect(s) of the action.
        /// </summary>
        public ITargetable Target { get; }

        /// <summary>
        ///     The actual value of the effect that was applied, after taking into
        ///     account resistances and/or other effects.
        /// </summary>
        public int AdjustedValue { get; }

        public ICharacter Self { get; set; }

        public Party Allies { get; set; }

        public Party Enemies { get; set; }
    }
}