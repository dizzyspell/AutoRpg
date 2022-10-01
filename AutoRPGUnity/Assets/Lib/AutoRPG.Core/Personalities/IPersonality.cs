using AutoRPG.Core.Actions;
using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Personalities
{
    /// <summary>
    ///     How an entity should behave in any given context. Defines it's core
    ///     descision-making logic.
    /// </summary>
    public interface IPersonality
    {
        /// <summary>
        ///     The user-presentable name of the personality, like "Unhinged" or "Stoic".
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The context used for descision-making. This should be kept up-to-date
        ///     at all times!!
        /// </summary>
        public IContext Context { get; set; }

        /// <summary>
        ///     Pick an <see cref="IAction" /> to do and do it!!
        /// </summary>
        /// <param name="aActionSet">The set of available actions to choose from</param>
        /// <returns>
        ///     The <see cref="ActionContext" /> which describes the execution and outcome
        ///     of whatever action this personality chose to do.
        /// </returns>
        public ActionContext DoAnyAction(ActionSet aActionSet);
    }
}