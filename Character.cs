using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame
{
    class Character 
    {
        public List<Action> moveset = new List<Action>();
        public string name; 
        public int health;
        public int strength;
        public int agility; 
        public int intelligence;
        public int luck;
        public int vitality;
        public int level;
        public int team;
        public int exp;  
       
        public Character(string _name, int lvl,int str, int agi, int intel, int lck, int vit, int _team) //basic character template
        {
            name = _name;
            level = lvl;           
            strength = str;
            agility = agi;
            intelligence = intel;
            luck = lck;
            vitality = vit;
            health = level * (vit * 2 + 5) + 50;
            team = _team;
            moveset.Add(new Action(1,"Punch", 2, 1, strength, 1));
        }

        //---------------------------------------------------------------------------------------------

        public void showCharInfo()      //Display the current stats of the character
        {
            Console.WriteLine("Name : {0}", name);
            Console.WriteLine("level : {5}\nhealth : {6}\nstrength : {0}\nagility : {1}\nintelligence : {2}\nluck : {3}\nvitality : {4}\nTeam : {7}\n", 
                strength, agility, intelligence, luck, vitality, level, health, team);
        }
       
        public bool isAlive()
        {
            if(health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Character selectTarget(List<Character> participants) // for cpu usage
        {
            return participants.First(player => player.team == 1);
                          
        }

        int calculateThreat() // future feature, ignore for now
        {
            return 0;
        }

        public void waitForCommand(List<Character> participants)    //use thie command to prompt skill and target from user
        {
            
            string moveInput;          
            string targetInput;
            int moveNum = 0;
            int targetNum = 0;
            bool validInput;

            int i = 0;
            foreach(Action move in moveset)
            {           
                Console.WriteLine("{0}. {1}", i, move.name);
                i++;
            }         


            //--------------------VERIFY INPUT FOR SKILL SELECTION--------------------------------------------
            validInput = false;
            Console.WriteLine("Input Move Number :");
            while (!validInput)
            {               
                moveInput = Console.ReadLine();
                if (Int32.TryParse(moveInput, out moveNum))
                {
                    moveNum = Convert.ToInt32(moveInput);
                    if(moveset.Count -1 >= moveNum)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, please enter a number from the list.");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Input, please enter a number from the list.");
                }
              
            }
            //-------------------------------------------------------------------------------------------------   

            i = 0;
            foreach (Character participant in participants)
            {
                Console.WriteLine("{0}. {1}", i, participant.name);
                i++;
            }

            //--------------------VERIFY INPUT FOR TARGET SELECTION---------------------------------------------
            validInput = false;
            Console.WriteLine("Input Target Number :");
            while (!validInput)
            {
               targetInput = Console.ReadLine();
                if (Int32.TryParse(targetInput, out targetNum))
                {
                    targetNum = Convert.ToInt32(targetNum);
                    if (participants.Count - 1 >= targetNum)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, please enter a number from the list.");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Input, please enter a number from the list.");
                }

            }
            //-------------------------------------------------------------------------------------------------   

            moveset[moveNum].affectTarget(participants[targetNum],this);          
            checkEnemy(participants[targetNum]);

        }

        private void checkEnemy(Character target)
        {
            if(!target.isAlive())
            {
                gainExp(100);
            }
        }

        private void gainExp(int expParam)
        {
            exp += expParam;
            if(exp >= level * 100)    // needs to be improved to accomodate multiple levelups 
            {
                levelUp();
            }
        }

        private void levelUp()
        {
            strength += 1;
            level += 1;
        }

    }
}
