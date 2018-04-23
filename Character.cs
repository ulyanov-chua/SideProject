using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame
{
    class Character
    {

        string name;
        int strength;
        int agility;
        int intelligence;
        int luck;
        int vitality;

        public Character()
        {
            strength = 3;
            agility = 3;
            intelligence = 3;
            luck = 3;
            vitality = 3;
        }

        public void showCharInfo()
        {
            Console.WriteLine("Name : {0}", name);
            Console.WriteLine("strength : {0}\nagility : {1}\nintelligence : {2}\nluck : {3}\nvitality : {4}\n", strength, agility, intelligence, luck, vitality);
        }

        public void basicAttack(Character target)
        {

        }

        public void setName(string newName)
        {
            name = newName;
        }

       

    }
}
