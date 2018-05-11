using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame
{
    class Action
    {
        public string name;
        int basePower;
        int statModifier;
        int modPower;
        int targetStat;

        public Action(string _name, int _basePower, int _statModifier, int _modPower, int _targetStat)
        {
            name = _name;
            basePower = _basePower;
            statModifier = _statModifier;
            modPower = _modPower;
            targetStat = _targetStat;
        }

        public void affectTarget(Character target)
        {
            switch (targetStat)
            {
                case 1:
                    target.health -= basePower + (statModifier * modPower);
                    break;
                default:
                    Console.WriteLine("something is wrong with this move");
                    break;
            }

            Console.WriteLine("{0} is hit with {1} and is dealt {2} damage",target.name,name, basePower + (statModifier * modPower));

        }

    }
}
