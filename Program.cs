using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Character player = new Character("Dogshit", 1, 1, 1, 1, 1, 1, 2);
            bool invalidInput = true;
            int input;
            FileManager asd = new FileManager();

            while (invalidInput)
            {
                Console.WriteLine("1.New Game");
                Console.WriteLine("2.Load Game");
                input = Convert.ToInt16(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        player = asd.CreateSave();
                        invalidInput = false;
                        break;
                    case 2:
                        player = asd.LoadSave();
                        invalidInput = false;
                        break;
                    default:
                        break;
                }
            }
            player.showCharInfo();              
           
            Character enemy = new Character("Dogshit", 1, 1, 1, 1, 1, 1,2);
            enemy.showCharInfo();
            Console.ReadKey();

            Battle ass = new Battle(player,enemy);
            ass.initiateBattle();
            ass.fight();

            asd.SaveCharacter(player);

            Console.ReadKey();

        }
    }
}
