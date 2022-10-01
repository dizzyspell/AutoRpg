using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRPG.Core.Contexts
{
    /// <summary>
    ///     An <see cref="IContext" /> which represents a battle that an
    ///     <see cref="ICharacter" /> is in. This also contains stuff for managing a
    ///     battle, tho only one at a time! (Need to make this able to run multiple)
    /// </summary>
    public class BattleContext : IContext
    {
        /// <summary>
        ///     The order in which turns will be executed. Also the list of all characters
        ///     involved in the battle.
        /// </summary>
        private static readonly List<ICharacter> msrInitiativeOrder = new List<ICharacter>();

        /// <summary>
        ///     Contruct a new BattleContext.
        /// </summary>
        /// <param name="aSelf">
        ///     <see cref="IContext.Self" />
        /// </param>
        /// <param name="aAllies">
        ///     <see cref="IContext.Allies" />
        /// </param>
        /// <param name="aEnemies">
        ///     <see cref="IContext.Enemies" />
        /// </param>
        internal BattleContext(ICharacter aSelf, Party aAllies, Party aEnemies)
        {
            Self    = aSelf;
            Allies  = aAllies;
            Enemies = aEnemies;
        }

        public ICharacter Self { get; set; }

        public Party Allies { get; set; }

        public Party Enemies { get; set; }

        /// <summary>
        ///     Set up a battle between two parties! This will create and apply
        ///     BattleContexts to each member of each party, and set up turn order.
        /// </summary>
        /// <param name="aPartyA">The party which is going first in the battle</param>
        /// <param name="aPartyB">The party whcih is going second in the battle</param>
        public static void SetUpForBattle(Party aPartyA, Party aPartyB)
        {
            msrInitiativeOrder.Clear();
            foreach (var aCharacter in aPartyA)
                aCharacter.Context = new BattleContext(
                    aCharacter, aPartyA, aPartyB);

            foreach (var aCharacter in aPartyB)
                aCharacter.Context = new BattleContext(
                    aCharacter, aPartyB, aPartyA);

            for (var i = 0; i < 4; i++)
            {
                msrInitiativeOrder.Add(aPartyA.ElementAt(i));
                msrInitiativeOrder.Add(aPartyB.ElementAt(i));
            }
        }

        /// <summary>
        ///     Calculate the next round of the battle.
        /// </summary>
        /// <param name="aTurnCallback">
        ///     A callback function which will be called after each character's turn in
        ///     the battle. Use this for displaying/logging what happened during a turn.
        /// </param>
        public static void NextRound(Action<ActionContext> aTurnCallback)
        {
            foreach (var character in msrInitiativeOrder)
                character.ResetForRound();

            foreach (var fActiveCharacter in msrInitiativeOrder)
            {
                if (!fActiveCharacter.Context.Enemies.StillKickin) break;
                if (!fActiveCharacter.IsAlive) continue;

                var fResult = fActiveCharacter.DoAnyAction();

                aTurnCallback(fResult);
            }
        }
    }
}