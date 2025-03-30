using GuestBookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal static class GetGuestInfo
    {
        internal static void GetPartyName(GuestModel guest)
        {
            string partyName = "";
            do
            {
                Console.Write("Enter your party name: ");
                partyName = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(partyName) && partyName.Replace(" ", "").All(char.IsLetter))
                {
                    guest.PartyName = partyName;
                    break; // Valid input, exit loop
                }
                else
                {
                    Console.WriteLine("Invalid party name. Only letters and spaces are allowed. Try again:\n");
                }

            } while (true);
        }
        internal static int GetNumOfGuests(GuestModel guest)
        {
            bool isValidInput = false;
            int totalGuestCount = 0;

            do
            {
                Console.Write("Enter the num of guests: ");
                string outputNumTxt = Console.ReadLine();
                bool isParsed = int.TryParse(outputNumTxt, out int numOfGuests);

                if (isParsed == true)
                {
                    try
                    {
                        // Attempt to assign guest count — may trigger range exception
                        guest.NumberOfGuests = numOfGuests;
                        isValidInput = true; // only activates, if no exception occurs
                        totalGuestCount += guest.NumberOfGuests;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // Catches custom range validation from GuestModel.cs (1–50 only)
                        Console.WriteLine("The number you entered is out of the allowed range");
                        Console.WriteLine("Please enter a number between 1 and 50");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An unexpected error occurred while setting the number of guests");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input detected.");
                    Console.WriteLine("Please enter a **whole number** (no letters, symbols, or decimals) must be between 1 and 50");
                }
            } while (isValidInput == false);

            return totalGuestCount;
        }
        internal static void GetPartyMessage(GuestModel guest)
        {
            Console.Write("Enter your party message: ");
            guest.PartyMessage = Console.ReadLine();
        }
        internal static int GetGuestInformation(List<GuestModel> guests)
        {
            // Variable to control the loop asking for more guests
            string moreGuestsComing = "";

            // Tracks the total number of guests across all entries
            int totalNumOfGuests = 0;

            do
            {
                // Create a new GuestModel object 
                GuestModel guest = new GuestModel();

                // Get & Set the Party Name
                GetGuestInfo.GetPartyName(guest);

                // Get & Set the Number of Guests in the party and update total count
                totalNumOfGuests += GetGuestInfo.GetNumOfGuests(guest);

                // Get & Set a message from the guest (optional comment or greeting)
                GetGuestInfo.GetPartyMessage(guest);

                // Populate the List
                guests.Add(guest);

                // Ask if more guests are coming
                Console.WriteLine("Are there any more guests coming ? (y/n): ");
                moreGuestsComing = Console.ReadLine();

            } while (moreGuestsComing.ToLower() == "y"); // Continue loop if user enters 'y' || 'Y'

            return totalNumOfGuests;
        }
    }
}
