using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookLibrary.Models
{
    public class GuestModel
    {
        public string PartyName { get; set; }
        public string PartyMessage { get; set; }

        // Combines party name and number of guests into one display string
        public string PartyNameNumber
        {
            get 
            {
                return $"{PartyName} Party has {NumberOfGuests} awesome guest's in attendance";
            }
        }

        private int _numberOfGuests;

        public int NumberOfGuests
        {
            get
            {
                return _numberOfGuests;
            }
            set
            {
                if (value >= 1 && value <= 50)
                {
                    _numberOfGuests = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(NumberOfGuests), "num of guests must be between 1 and 50");
                }
            }
        }
    }
}


