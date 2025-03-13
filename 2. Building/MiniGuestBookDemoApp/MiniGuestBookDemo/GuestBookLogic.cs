using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGuestBookDemo
{
    internal static class GuestBookLogic
    {
        internal static void WelcomeIntro()
        {
            Console.WriteLine("Welcome to the Mini Guest Book App");
            Console.WriteLine("..................................");
            Console.WriteLine(); // leave blank space b4 starting
        }

        internal static string GetPartyName()
        {
            string partyName;
            do
            {
                Console.Write("Enter your party name: ");
                partyName = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(partyName) && partyName.Replace(" ", "").All(char.IsLetter))
                {
                    break; // Valid input, exit loop
                }
                else
                {
                    Console.WriteLine("Wrong name format, try again");
                }

            } while (true);

            return partyName;
        }

        internal static int GetPartySize()
        {
            bool isValidNum = false;
            int guestsNum;

            do
            {
                Console.Write("Enter your number of guests: ");
                string guestsTxt = Console.ReadLine().Trim();

                isValidNum = int.TryParse(guestsTxt, out guestsNum) && guestsNum >= 0; // convert from string to int and num > 0

                if (isValidNum == false)
                {
                    Console.WriteLine("Invalid input. Please enter a whole number (0 or more)");
                }

            } while (isValidNum != true);

            return guestsNum;
        }

        internal static (List<string> partyNameList, int totalGuests) GetAllGuestsNum()
        {           
            string partyName;
            List<string> partyNameList = new List<string>();
            int totalGuests = 0;

            do
            {
                partyNameList.Add(partyName = GuestBookLogic.GetPartyName());
                totalGuests += GuestBookLogic.GetPartySize();

            } while (GuestBookLogic.userDecision() == true);

            return (partyNameList, totalGuests);
        }
        internal static bool userDecision()
        {
            string userDecisionToContinue;
            bool isContinuing;

            do
            {
                Console.Write("are there any more guests coming ? (y/n): ");
                userDecisionToContinue = Console.ReadLine().Trim();

                if (userDecisionToContinue.ToLower() == "y" || userDecisionToContinue.ToLower() == "n")
                {
                    isContinuing = (userDecisionToContinue.ToLower() == "y"); // True for "y", False for "n"
                    Console.WriteLine();
                    break; // Exit loop
                }
                else
                {
                    Console.WriteLine("Wrong format, please enter 'y' or 'n'.");
                }

            } while (true);

            return isContinuing;
        }

        internal static void PrintGuestsList(List<string> partyNameList)
        {
            foreach (string item in partyNameList)
            {
                Console.WriteLine(item);
            }
        }

        internal static void EndApp(int totalGuests)
        {
            Console.WriteLine("Thank your everyone for attending");
            Console.WriteLine($"The total guest count for this evening was {totalGuests}");
        }
    }
}
