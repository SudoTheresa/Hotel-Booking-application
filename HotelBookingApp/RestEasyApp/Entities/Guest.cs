using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyApp.Database
{
    public class Guest
    {
        #region Guest Fields
        private int guestId;
        private bool inHotel;
        private string name;
        private string address;
        private string bookingDay;
        private int daysBookedIn;
        private int sumOfDaysBookedIn;
        private string creditCardDetails;
        #endregion

        #region Guest constructor
        public Guest()
        {
            name = "";
            address = "";
            bookingDay = "";
        }

        public Guest(string guestName, string guestAddress, string dayOfbooking)
        {
            name = guestName;
            address = guestAddress;
            bookingDay = dayOfbooking;
        }
        #endregion

        #region Guest Properties
        public int guestID {
            get { return guestId; }
            set { guestId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string BookingDay
        {
            get { return bookingDay; }
            set { bookingDay = value; }
        }
        public bool InHotel {
            get { return inHotel; }
            set { inHotel = value; }
        }
        public int daysBooked {
            get { return daysBookedIn; }
            set { daysBookedIn = value; }
        }

        public string CreditCardDetails {
            get { return creditCardDetails; }
            set { creditCardDetails = value; }
        }
        #endregion
    }
}
