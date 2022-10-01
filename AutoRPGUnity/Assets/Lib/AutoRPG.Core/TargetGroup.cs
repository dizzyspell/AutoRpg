using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AutoRPG.Core
{
    /// <summary>
    ///     An <see cref="ITargetable" /> which represents multiple
    ///     <see cref="ITargetable" />! Confusing!
    /// </summary>
    public class TargetGroup : IEnumerable<ITargetable>, ITargetable
    {
        private readonly List<ITargetable> mrTargets;

        /// <summary>
        ///     Create a new TargetGroup from a list of targets.
        /// </summary>
        /// <param name="aTargets"></param>
        public TargetGroup(List<ITargetable> aTargets)
        {
            mrTargets = aTargets;
        }

        public IEnumerator<ITargetable> GetEnumerator()
        {
            return mrTargets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string Name => string.Join(", ", mrTargets.Select(a => a.Name));

        public int SimulateDamage(int aBaseDamage)
        {
            return mrTargets.Sum(aTarget => aTarget.SimulateDamage(aBaseDamage));
        }

        public int ApplyDamage(int aBaseDamage)
        {
            return mrTargets.Sum(aTarget => aTarget.ApplyDamage(aBaseDamage));
        }

        public int SimulateDefense(int aBaseDefense)
        {
            return mrTargets.Sum(aTarget => aTarget.SimulateDefense(aBaseDefense));
        }

        public int ApplyDefense(int aBaseDefense)
        {
            return mrTargets.Sum(aTarget => aTarget.ApplyDefense(aBaseDefense));
        }

        public int SimulateHeal(int aBaseHeal)
        {
            return mrTargets.Sum(aTarget => aTarget.SimulateHeal(aBaseHeal));
        }

        public int ApplyHeal(int aBaseHeal)
        {
            return mrTargets.Sum(aTarget => aTarget.ApplyHeal(aBaseHeal));
        }

        public static explicit operator TargetGroup(List<ITargetable> a)
        {
            return new TargetGroup(a);
        }

        public static explicit operator TargetGroup(List<ICharacter> a)
        {
            return new TargetGroup(
                a.Cast<ITargetable>().ToList());
        }

        public static explicit operator TargetGroup(Party p)
        {
            return new TargetGroup(
                p.Where(a => a != null)
                    .Cast<ITargetable>().ToList());
        }
    }
}