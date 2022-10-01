using AutoRPG.Core.Actions;

namespace AutoRPG.Core.Classes
{
    /// <summary>
    ///     An in-game character class, which defines what a character can do and ow it
    ///     does that stuff!
    /// </summary>
    public interface IClass
    {
        /// <summary>
        ///     The user-presentable name of the class.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The base <see cref="Actions.ActionSet" /> for the class - this should be *copied*
        ///     to a character when a class is applied, so that the base set does not
        ///     get modified!!
        /// </summary>
        public ActionSet ActionSet { get; }
    }
}