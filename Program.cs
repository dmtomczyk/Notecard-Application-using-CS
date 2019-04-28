using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myApp
{
    //  Our Main class
    class Program
    {

        //  Initializing variables
        string cardName = "";
        string cardMessage = "";
        string dateCreated = "";
        static IList<Program> historyOfCards = new List<Program>();

        // int wordCount = 0; TODO:
        // string dateModified = ""; TODO:

        // Contsructor (must have same name as class)
        public Program(string name, string message, string created)
        {
            // Setting defaults for each card
            cardName = name;
            cardMessage = message;
            // wordCount = 0;
            dateCreated = created;
            // dateModified = modified;
        }

        public static void makeCard()
        {
            // READING Card Name Input
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEnter a Name for the Notecard: ");
            Console.ResetColor();
            string cardName = Console.ReadLine();

            // READING Card Message
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter a Message for the Notecard: ");
            Console.ResetColor();
            string cardMessage = Console.ReadLine();

            // READING Date of Entry
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the \"Date of Entry\": ");
            Console.ResetColor();
            string dateCreated = Console.ReadLine();

            // Creating a new card with all gathered variables
            Program newCard = new Program(cardName, cardMessage, dateCreated);
            historyOfCards.Add(newCard);

            // DEBUG: Print attributes of the new object
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nDetails of your new card:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("CardName = " + newCard.cardName);
            Console.WriteLine("CardMessage = " + newCard.cardMessage);
            Console.WriteLine("CardDate = " + newCard.dateCreated);
            Console.ResetColor();
            Console.WriteLine("");
        }

        public static void searchCard()
        {
            int count = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nBelow are all available cards and their index's.");
            Console.ResetColor();

            // Printing out names of elements
            foreach (var instance in historyOfCards)
            {
                Console.WriteLine(instance.cardName + " has an Index of " + count);
                count++;
            }

            // Determine the index of the wanted card
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nWhat is the index of the card you are looking for?");
            Console.ResetColor();
            String indexOfCard = Console.ReadLine();

            // Print the details using our other function
            int myInt;
            bool isNumber = int.TryParse(indexOfCard, out myInt);
            if (isNumber)
            {
                printDetails(myInt);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You did not enter a number!");
                Console.ResetColor();
            }
        }

        public static void printDetails(int index)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Card Name: " + historyOfCards[index].cardName);
            Console.WriteLine("Card Message: " + historyOfCards[index].cardMessage);
            Console.WriteLine("Card Date: " + historyOfCards[index].dateCreated);
            Console.WriteLine("");
        }

        // Main Method -- to call our functions
        public static void Main()
        {
            while (true)
            {
                // Asking user if they want a new card, then creating the new card
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Options:\nType \"Y\" to create a new Notecard.\nType \"N\" to exit the application.\nType \"S\" to look at old notecards.");
                Console.ResetColor();
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    makeCard();
                }
                else if (answer == "S")
                {
                    // Print all cards, ask for index, return details of index.
                    searchCard();
                }
                else if (answer != "N")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Not a valid input!");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Exiting...");
                    Console.ResetColor();
                    break;
                }

            }

            // Todays Data (TODO: Create data using detection)
        }
    }
}
