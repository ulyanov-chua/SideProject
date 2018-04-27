using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame
{
    class Item
    {

        string name;
        int slot;
        int armorStat;
        int damage;

        public Item(string _name, int slotParam, int armor, int dmg)
        {
            name = _name;
            slot = slotParam;
            armorStat = armor;
            damage = dmg;

        }

        public void pickUp()
        {
            Console.WriteLine("picked up: {0}", name);
            if (damage == 0)
                Console.WriteLine("{0}, Stats : {1} armor\n", name, armorStat);
            else
                Console.WriteLine("{0}, Stats : {1} weapon damage\n", name, damage);
        }


    }
}
