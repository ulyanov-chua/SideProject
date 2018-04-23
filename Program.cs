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
            Console.WriteLine("enter character name :");
            Character player = new Character();
            player.setName(Console.ReadLine());
            player.showCharInfo();
            Console.ReadKey();
        }
    }
}
