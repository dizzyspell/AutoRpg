using System;
using System.Collections.Generic;
using System.Linq;
using AutoRPG.Core.Classes;
using AutoRPG.Core.Personalities;

namespace AutoRPG.Core
{
    /// <summary>
    ///     Omnipotent source of randomness. All hail.
    /// </summary>
    public static class RandomNumberGod
    {
        private static readonly Random msrRng = new Random();

        /// <summary>
        ///     Choose an int up to the max (exclusive)
        /// </summary>
        /// <param name="aMax">The max value to generate (exclusive)</param>
        /// <returns>A random int, less than the specified max.</returns>
        public static int ChooseInt(int aMax = 10)
        {
            return msrRng.Next(0, aMax);
        }

        /// <summary>
        ///     Choose a random name from the default names.
        /// </summary>
        /// <returns>A name, obvs</returns>
        public static string ChooseName()
        {
            return Defaults.Names[msrRng.Next(0, Defaults.Names.Count)];
        }

        /// <summary>
        ///     Choose a random class from the default classes.
        /// </summary>
        /// <returns>A new instance of a random class</returns>
        public static IClass ChooseClass()
        {
            return Defaults.Classes.ElementAt(ChooseInt(Defaults.Classes.Count))
                .Value.Invoke();
        }

        /// <summary>
        ///     Choose a random personality from the default personalities.
        /// </summary>
        /// <returns>A new instance of a random personality</returns>
        public static IPersonality ChoosePersonality()
        {
            return Defaults.Personalities
                .ElementAt(ChooseInt(Defaults.Personalities.Count))
                .Value.Invoke();
        }

        /// <summary>
        ///     Chose a random character from a pool of characters.
        /// </summary>
        /// <param name="aPool">The pool to select from</param>
        /// <returns>A random character from the pool</returns>
        public static ICharacter ChooseCharacter(IEnumerable<ICharacter> aPool)
        {
            var fCharacters = aPool.ToList();
            return fCharacters.ElementAt(ChooseInt(fCharacters.Count));
        }

        /// <summary>
        ///     Choose a random target from a pool of targets.
        /// </summary>
        /// <param name="aPool">The pool to select from</param>
        /// <returns>A random target from the given pool</returns>
        public static ITargetable ChooseTarget(IEnumerable<ITargetable> aPool)
        {
            var fTargets = aPool.ToList();
            return fTargets.ElementAt(ChooseInt(fTargets.Count));
        }
    }
}