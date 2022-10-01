using System.Collections.Generic;
using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions
{
    /// <summary>
    ///     An in-game action, which can be executed by something on something else in
    ///     order to apply some effect(s).
    /// </summary>
    public interface IAction
    {
        /// <summary>
        ///     The user-side name of the action
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     What the action does, in brief. This should be rather vague :)
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     What <see cref="ActionType" /> this action is classified as. This is
        ///     mainly so that we don't have to use reflection to get this information.
        /// </summary>
        public ActionType Type { get; }

        /// <summary>
        ///     Do what the action is supposed to do - apply effects and whatnot to the
        ///     specified <see cref="ITargetable" />.
        /// </summary>
        /// <param name="aContext">The current context in which the action is occurring</param>
        /// <param name="aTarget">The target for the main effect(s) of this action</param>
        /// <returns>
        ///     An <see cref="ActionContext" /> which contains information about the
        ///     execution and outcome of this action.
        /// </returns>
        public ActionContext Execute(IContext aContext, ITargetable aTarget);

        /// <summary>
        ///     Checks the given <see cref="IContext" /> for valid targets for the action,
        ///     and occaisionally sorts them by relevant parameteres (that may change soon)
        /// </summary>
        /// <param name="aContext">The current context that the action would occur in</param>
        /// <returns>
        ///     A list of valid targets for the main effect(s) of the action, within
        ///     the given context. May be empty if there are no valid targets!
        /// </returns>
        public IEnumerable<ITargetable> ValidTargets(IContext aContext);
    }
}