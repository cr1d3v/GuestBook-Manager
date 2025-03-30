using GuestBookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class ConsoleMessages
    {
        internal static void WelcomeIntro()
        {
            Console.WriteLine("Welcome!\nYou're now using version 2 of the Mini Guest Book App");
            Console.WriteLine("......................................................");
            Console.WriteLine(); // blank line for spacing
        }

        internal static void DisplayData(List<GuestModel> guests, int totalNumOfGuests)
        {
            foreach (GuestModel item in guests)
            {
                Console.WriteLine($"\n{item.PartyNameNumber}");
                Console.WriteLine($"{item.PartyName} said: {item.PartyMessage}");
            }
            ConsoleMessages.FinalMessage(totalNumOfGuests);
        }
        private static void FinalMessage(int totalNumOfGuests)
        {

            Console.WriteLine("\n......................................................");
            Console.WriteLine("Thank you all for joining us tonight!");
            Console.WriteLine($"We had a total of {totalNumOfGuests} guest(s) this evening");
        }

    }
}
