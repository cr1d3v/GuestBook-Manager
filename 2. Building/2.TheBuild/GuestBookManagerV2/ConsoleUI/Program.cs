using System;
using ConsoleUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestBookLibrary.Models;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // List to store all guest entries
            List<GuestModel> guests = new List<GuestModel>();

            // Display the WelcomeMessage
            ConsoleMessages.WelcomeIntro();

            // Gather info for displaying
            int totalNumOfGuests = GetGuestInfo.GetGuestInformation(guests);

            // Display the Core Data + Wrap-up
            ConsoleMessages.DisplayData(guests, totalNumOfGuests);

            Console.ReadLine(); // pause the app
        }
    }
}
