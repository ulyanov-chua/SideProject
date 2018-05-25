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
        int ID;
        int basePower;
        int statModifier;
        int modPower;
        int targetStat;
        int totalDmg;

        public Action(int _ID, string _name, int _basePower, int _statModifier, int _modPower, int _targetStat)
        {
            ID = _ID;
            name = _name;
            basePower = _basePower;
            statModifier = _statModifier;
            modPower = _modPower;
            targetStat = _targetStat;
        }

        public void affectTarget(Character target, Character user)
        {
            switch (statModifier)
            {
                case 2:
                    totalDmg = basePower + (user.strength * modPower);
                    break;
            }

            switch (targetStat)
            {
                case 1:
                    target.health -= totalDmg;
                    break;
                default:
                    Console.WriteLine("something is wrong with this move");
                    break;
            }

            Console.WriteLine("{0} is hit with {1} and is dealt {2} damage",target.name,name, totalDmg);

        }

    }
}
