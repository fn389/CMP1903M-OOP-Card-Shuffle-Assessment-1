using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        //Since it was requested to make only one pack of cards in the entire program, I made it a public static variable
        //This way it can be accessed from any class and/or method as well as from other programs and games that use these classes.
        public static List<Card> pack = new List<Card>();
        //Constructor that's initialised at the start of the program to assign the values to the list
        static Pack()
        {
            //Initialise the card pack here
            int[] suits = { 1, 2, 3, 4 };
            foreach (int suit in suits) //These loops give the value from all of the possible cards vals and suits 
            {
                for (int i = 1; i <= 13; i++)
                {
                    Card card = new Card(i, suit);
                    Pack.pack.Add(card);
                }
            }

        }

        //This method calls the other methods which shuffle the cards
        public static bool shuffleCardPack(int typeOfShuffle) 
        {
            Pack shufflePack = new Pack();
            if (typeOfShuffle == 1)
            {
                FisherYates();
                Console.WriteLine("Fisher Yates shuffle complete");
                Console.WriteLine("Returning to test menu...");
            }
            else if (typeOfShuffle == 2)
            {
                RiffleShuffle();
                Console.WriteLine("Riffle Shuffle complete");
                Console.WriteLine("Returning to test menu...");
            }
            else if (typeOfShuffle == 3)
            {
                Console.WriteLine("No shuffle done");
                Console.WriteLine("Returning to test menu...");
            }
            return false;
            //Shuffles the pack based on the type of shuffle

        }

        //This method deals a card from the top of the pack and returns the value of the Card variable.
        public static Card deal() 
        {
            int topOfPack = Pack.pack.Count() - 1;
            Card tempCard = Pack.pack[topOfPack];
            Pack.pack.Remove(tempCard);
            return tempCard;
            //Deals one card

        }

        //This method takes an int value and deals that amount of cards from the top of the deck.
        //The return value this time is the actual deck.
        public static List<Card> dealCard(int amount) 
        {
            for (int x = 0; x <= amount; x++)
            {
                int topOfPack = Pack.pack.Count() - 1;
                Card tempCard = Pack.pack[topOfPack];
                Pack.pack.Remove(tempCard);
            }
            return Pack.pack;
            //Deals the number of cards specified by 'amount'
        }
        //This method performs the Fisher Yates shuffle which uses a random number generator which is used when moving the cards
        public static void FisherYates()
        {
            Random random = new Random();
            for (int i = Pack.pack.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = Pack.pack[j];
                Pack.pack[j] = Pack.pack[i];
                Pack.pack[i] = temp;
            }
        }

        //This method performs the Riffle Shuffle on the pack of cards
        //It will split the pack into half and will put the cards back into the pack one by one 
        public static void RiffleShuffle()
        {
            Random random = new Random();
            int middle = Pack.pack.Count / 2;
            List<Card> left = Pack.pack.GetRange(0, pack.Count / 2);
            List<Card> right = Pack.pack.GetRange(pack.Count / 2, pack.Count - pack.Count / 2);

            Pack.pack.Clear();
            while (left.Count > 0 && right.Count > 0)
            {
                int index = random.Next(2);
                if (index == 0)
                {
                    Pack.pack.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    Pack.pack.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            Pack.pack.AddRange(left);
            Pack.pack.AddRange(right);
        }
    }
}
