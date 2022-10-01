using System;

namespace AutoRPG.Core.Actions
{
    /// <summary>
    ///     A standardized set of <see cref="IAction" />s, currently one of each <see cref="ActionType" />
    /// </summary>
    public class ActionSet
    {
        internal ActionSet(
            IAction aBasic, IAction aSupport, IAction aDefend, IAction aAttack)
        {
            Basic   = VerifyActionType(aBasic, ActionType.Basic);
            Support = VerifyActionType(aSupport, ActionType.Support);
            Defend  = VerifyActionType(aDefend, ActionType.Defend);
            Attack  = VerifyActionType(aAttack, ActionType.Attack);
        }

        public IAction Basic { get; }

        public IAction Support { get; }

        public IAction Defend { get; }

        public IAction Attack { get; }

        /// <summary>
        ///     User-presentable representation of the action set, names only. Mainly
        ///     for the console app.
        /// </summary>
        public string Summary => "\n> " + string.Join(
            "\n> ", Basic.Name, Support.Name, Defend.Name, Attack.Name);

        /// <summary>
        ///     Verify that an action's type matches the one we're expecting.
        /// </summary>
        /// <param name="aActionToCheck">The action who's type we're checking, obvs</param>
        /// <param name="aTypeItShouldBe">The type of action it should be, obvs</param>
        /// <returns>The action we were checking, if it is of the expected type. Otherwise, this method throws an exception.</returns>
        /// <exception cref="ArgumentException" />
        private IAction VerifyActionType(
            IAction aActionToCheck, ActionType aTypeItShouldBe)
        {
            if (aActionToCheck.Type != aTypeItShouldBe)
                throw new ArgumentException(
                    $"Action {aActionToCheck} was supposed to be {aTypeItShouldBe} - instead it was {aActionToCheck.Type}");
            return aActionToCheck;
        }
    }
}