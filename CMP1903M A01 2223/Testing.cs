using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMP1903M_A01_2223
{
    class Testing
    {
        //This is the only public method in this class the rest are private so that means they can only be called through here
        //From here the Menu method is called
        public Testing()
        {
            StartTest();
        }
        public void StartTest() 
        {
            Pack pack = new Pack();
            string choice = "0";
            Console.WriteLine("Starting testing:");
            Menu(choice);
        }
        
        //This method is called from the Menu method and calls the shuffleCardPack method from Pack
        //Also collects the user's input on which shuffle method to use
        private void shuffleTest()
        {
            int shuffleChoice;
            string menuChoice = "0";
            Console.WriteLine("Select shuffle type ");
            Console.WriteLine("1. Fisher Yates");
            Console.WriteLine("2. Riffle Shuffle");
            Console.WriteLine("3. None");
            menuChoice = Console.ReadLine();
            if (menuChoice == "1" || menuChoice == "2" || menuChoice == "3")
            {
                shuffleChoice = int.Parse(menuChoice); //Using string and converting to int is necessary to stop erroneous inputs such as non int values
                Pack.shuffleCardPack(shuffleChoice);
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid choice, going back to test menu...");
            }
        }

        //Called from the Menu class, is used to call test the deal method
        //Also calls the getValue and getSuit methods to get the two variables in string format to make it more readable for the user
        private void dealTest()
        {
            Card dealReturn = Pack.deal();
            string val = getValue(dealReturn);
            string suit = getSuit(dealReturn);
            Console.WriteLine($"Dealt {val} of {suit}"); 
        }
        //Calls the dealCard method and gets a returned value from it 
        private void dealCardTest()
        {
            Console.WriteLine("How many cards do you want to deal? ");
            int numOfCards = int.Parse(Console.ReadLine());
            Pack.pack = Pack.dealCard(numOfCards);
        }
        //getValue and getSuit are used to turn the string values of the cards into string so they're more readable for the user
        private string getValue(Card dealReturn)
        {
            string strVal;
            if (dealReturn.Value == 1)
            {
                strVal = "Ace";
            }
            else if (dealReturn.Value == 11)
            {
                strVal = "Jack";
            }
            else if (dealReturn.Value == 12)
            {
                strVal = "Queen";
            }
            else if (dealReturn.Value == 13)
            {
                strVal = "King";
            }
            else
            {
                strVal = dealReturn.Value.ToString();
            }
            return strVal;
        }

        private string getSuit(Card dealReturn)
        {
            string strSuit;
            if (dealReturn.Suit == 1)
            {
                strSuit = "Hearts";
            }
            else if (dealReturn.Suit == 2)
            {
                strSuit = "Diamonds";
            }
            else if (dealReturn.Suit == 3)
            {
                strSuit = "Clubs";
            }
            else
            {
                strSuit = "Spades";
            }
            return strSuit;
        }

        //Menu is called from the start test method and is private so it can be only accessed from the other method
        //This method is also used to call other methods and acts as a UI for the user.
        private void Menu(string choice)
        {
            while (choice != "4") //Using string is necessary to stop erroneous inputs such as non int values
            {
                Console.WriteLine("");
                Console.WriteLine("Select an option");
                Console.WriteLine("1. Perform one of the shuffle tests");
                Console.WriteLine("2. Test the deal method");
                Console.WriteLine("3. Test the dealCard method");
                Console.WriteLine("4. Quit");
                Console.WriteLine("5. Reset pack of cards");
                Console.WriteLine("");
                choice = Console.ReadLine();
                Console.WriteLine("");
                if (choice == "1")
                {
                    Console.WriteLine("Starting shuffle");
                    shuffleTest();
                }
                else if (choice == "2")
                {
                    dealTest();
                }
                else if (choice == "3")
                {
                    dealCardTest();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Quitting testing");
                    break;
                }
                else if (choice == "5")
                {
                    Pack pack = new Pack();
                }
                else
                {
                    Console.WriteLine("Option invalid");
                }

            }
        }
    }
}
