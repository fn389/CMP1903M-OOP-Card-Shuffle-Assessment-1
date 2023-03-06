using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Pack pack = new Pack();
            Card card = Pack.pack[0];
            Console.WriteLine($"Start: Card: {card.Value} of {card.Suit}");

            Pack.shuffleCardPack(1);
            card = Pack.pack[0];
            Console.WriteLine($"FisherYates: Card: {card.Value} of {card.Suit}");
            Pack.shuffleCardPack(2);
            card = Pack.pack[0];
            Console.WriteLine($"RiffleShuffle Card: {card.Value} of {card.Suit}");
            Console.ReadLine();*/

            Console.WriteLine("Running program");
            Testing test = new Testing();
            test.StartTest();
            Console.WriteLine("Program done, press enter to quit");
            Console.ReadLine();
        }
    }
}
