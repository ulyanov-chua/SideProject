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
        int health;
        int strength;
        int agility;
        int intelligence;
        int luck;
        int vitality;
        int level;

        public Character()
        {
            level = 1;           
            strength = 3;
            agility = 3;
            intelligence = 3;
            luck = 3;
            vitality = 3;
            health = level * (vitality * 2 + 5) + 50;
        }

        public Character(string _name, int lvl,int str, int agi, int intel, int lck, int vit) //use for creating enemies
        {
            name = _name;
            level = lvl;           
            strength = str;
            agility = agi;
            intelligence = intel;
            luck = lck;
            vitality = vit;
            health = level * (vit * 2 + 5) + 50;
        }

        public void showCharInfo()
        {
            Console.WriteLine("Name : {0}", name);
            Console.WriteLine("level : {5}\nhealth : {6}\nstrength : {0}\nagility : {1}\nintelligence : {2}\nluck : {3}\nvitality : {4}\n", 
                strength, agility, intelligence, luck, vitality, level, health);
        }

        public void basicAttack(Character target)
        {
            target.health -= strength;
        }

        public void setName(string newName)
        {
            name = newName;
        }

        

    }
}
