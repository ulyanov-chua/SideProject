using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gladiatorGame
{
    class Battle 
    {

        List<Character> participants = new List<Character>();   // list of living participants
        List<Character> casualties = new List<Character>();     // list of participants who died in the battle
       
        public Battle(Character player, Character enemy)    // method that adds two opposing people in a battle, improve this to be bale to take any reasonable amount (2 to 6 maybe)
        {
            participants.Add(enemy);    
            participants.Add(player);   
        }

        public void initiateBattle()
        {

            participants.Sort((x, y) => y.agility.CompareTo(x.agility));       // sort the list based on the agility of perople in the battle (participants)     
          
        }

        public void fight()
        {
            //if(participants.Any(c => c.team == 1 ) && participants.Any(c => c.team == 1)) // old thingy, ignore lang

            //while (allied.Count > 0 && enemies.Count > 0)
            //{
            //    participants[0].basicAttack(participants[1]);
            //    participants[1].showCharInfo();
            //    Console.ReadKey();
            //}           

            while (participants.Any(c => c.team == 1) && participants.Any(c => c.team == 2)) // while an enemy is alive continue the fight
            {

                Character target;

                for(int i = 0; i < participants.Count(); i++)   
                {
                    if (participants[i].team == 2) // if enemy, enemy will select the first player unit
                    {
                        target = participants[i].selectTarget(participants);
                        participants[i].moveset[0].affectTarget(target);
                        target.showCharInfo();
                    }
                    else
                    {
                        //participants[i].basicAttack(participants[1]);
                        participants[i].waitForCommand(participants);       // character method that takes user input and performs action based on that
                        participants[1].showCharInfo();
                    }                   

                }
                            
                if (!participants[1].isAlive())     // should create a die method in the character class that gets called when character dies instead of this <--- IMPORTANT!!! ---------------
                {
                    casualties.Add(participants[1]);
                    participants.RemoveAt(1);
                }

                Console.ReadKey();

            }

        }

    }
}
