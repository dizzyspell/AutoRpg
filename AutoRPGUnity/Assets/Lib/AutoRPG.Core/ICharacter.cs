using System;
using AutoRPG.Core.Actions;
using AutoRPG.Core.Classes;
using AutoRPG.Core.Contexts;
using AutoRPG.Core.Personalities;

namespace AutoRPG.Core
{
    /// <summary>
    ///     An in-game entity which can do stuff and have stuff done it it...
    ///     I'm sure you've heard of the concept lol
    /// </summary>
    public interface ICharacter : ITargetable
    {
        /// <summary>
        ///     Id used for determining uniqueness - this way, the name can change and
        ///     the character is still identifiable!
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        ///     The base <see cref="IClass" /> used when setting up the character, and beyond!
        /// </summary>
        public IClass Class { get; }

        /// <summary>
        ///     The <see cref="IPersonality" /> which defines this critter's core
        ///     decision-making logic.
        /// </summary>
        public IPersonality Personality { get; }

        /// <summary>
        ///     Defines what actions the ICharacter can currently do.
        /// </summary>
        public ActionSet ActionSet { get; }

        /// <summary>
        ///     Self-explanatory, I think.
        /// </summary>
        public int HealthPoints { get; }

        /// <summary>
        ///     Basically, temporary health points that absorb damage.
        /// </summary>
        public int DefensePoints { get; }

        /// <summary>
        ///     If health points > 0, basically
        /// </summary>
        public bool IsAlive { get; }

        /// <summary>
        ///     User-presentable, one-line summary of the character.
        /// </summary>
        public string Summary { get; }

        /// <summary>
        ///     User-presentable, multi-line description of the character and what it
        ///     can do. Mainly just for the console app!
        /// </summary>
        public string Details { get; }

        /// <summary>
        ///     The current context, from the ICharacter's perspective. Keep this
        ///     up-to-date at all times!!
        /// </summary>
        public IContext Context { get; set; }

        /// <summary>
        ///     Choose an action from the ones available and do it!
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionContext" /> which describes the execution and outcome
        ///     of whatever action this entity chose to do.
        /// </returns>
        public ActionContext DoAnyAction();

        /// <summary>
        ///     Clear any round-resetable effects.
        /// </summary>
        public void ResetForRound();
    }
}