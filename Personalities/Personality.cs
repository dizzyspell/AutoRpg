using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Actions;

namespace ConsoleApp1.Personalities
{
    internal abstract class Personality : IPersonality
    {
        private readonly string mrName;
        private readonly int mrBasicChance;
        private readonly int mrSupportChance;
        private readonly int mrDefendChance;
        private readonly int mrAttackChance;
        private readonly int mrTotalChance;

        protected Personality(string aName, int aBasicChance, int aSupportChance, int aDefendChance, int aAttackChance)
        {
            mrName = aName;
            mrBasicChance = aBasicChance;
            mrSupportChance = aSupportChance;
            mrDefendChance = aDefendChance;
            mrAttackChance = aAttackChance;
            mrTotalChance = aBasicChance + aSupportChance + aDefendChance + aAttackChance;
        }

        public string Name => mrName;

        public IAction ChooseAction(ActionSet aActionSet)
        {
            List<Tuple<IAction, int>> fChanceSet = new List<Tuple<IAction, int>>
            {
                new(aActionSet.Basic, mrBasicChance),
                new(aActionSet.Support, mrSupportChance),
                new(aActionSet.Defend, mrDefendChance),
                new(aActionSet.Attack, mrAttackChance)
            };

            int fRandInt = RandomNumberGod.ChooseInt(mrTotalChance);

            IAction fChosenAction = null;

            foreach (Tuple<IAction, int> _action in fChanceSet)
            {
                if (fRandInt < _action.Item2)
                {
                    fChosenAction = _action.Item1;
                    break;
                }

                fRandInt -= _action.Item2;
            }

            return fChosenAction;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
