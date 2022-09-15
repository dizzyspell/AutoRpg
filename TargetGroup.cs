using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TargetGroup : IEnumerable<ITargetable>, ITargetable
    {
        private readonly List<ITargetable> mrTargets;

        public TargetGroup(List<ITargetable> aTargets)
        {
            mrTargets = aTargets;
        }

        public string Name => string.Join(", ", mrTargets.Select(a => a.Name));

        public int ApplyDamage(int aBaseDamage)
        {
            int fTotalDamageApplied = 0;

            foreach (var fTarget in mrTargets)
            {
                fTotalDamageApplied += fTarget.ApplyDamage(aBaseDamage);
            }

            return fTotalDamageApplied;
        }

        public int ApplyDefense(int aBaseDefense)
        {
            int fTotalDefenseApplied = 0;

            foreach (var fTarget in mrTargets)
            {
                fTotalDefenseApplied += fTarget.ApplyDefense(aBaseDefense);
            }

            return fTotalDefenseApplied;
        }

        public int ApplyHeal(int aBaseHeal)
        {
            int fTotalHealApplied = 0;

            foreach (var fTarget in mrTargets)
            {
                fTotalHealApplied += fTarget.ApplyHeal(aBaseHeal);
            }

            return fTotalHealApplied;
        }

        public IEnumerator<ITargetable> GetEnumerator()
        {
            return mrTargets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static explicit operator TargetGroup(List<ITargetable> a)
        {
            return new TargetGroup(a);
        }

        public static explicit operator TargetGroup(List<ICharacter> a)
        {
            return new TargetGroup(a.Cast<ITargetable>().ToList());
        }
    }
}
