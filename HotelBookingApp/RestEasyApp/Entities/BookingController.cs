using RestEasyApp.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyApp.Entities
{
    public class BookingController
    {
        #region Data fields
        private BookingDB bookingDB;
        private Collection<Booking> bookings;
        #endregion

        #region Constructor
        public BookingController(){
            bookingDB = new BookingDB();
            bookings = bookingDB.allBookings;
        }
        #endregion

        #region Property Methods/Getter
        public Collection<Booking> allBookings {
            get { return bookings; }
            set { bookings = value; }
        }
        #endregion

        #region CRUD
        public void databaseAdd(Booking booking) {
             bookingDB.databaseAdd(booking);
        }
        public void Add(Booking booking) {
            booking.BookingId = 1+bookings.Count();
            databaseAdd(booking);
            bookings.Add(booking);
        }

        public void databaseEdit(Booking booking) {
            bookingDB.databaseEdit(booking);
        }

        public void Edit(Booking booking) {
            int count = findIndex(booking);
            bookings[count].DateIn = booking.DateIn;
            bookings[count].DateOut = booking.DateIn;
            bookings[count].Guestname = booking.Guestname;
            bookings[count].Pricing = booking.Pricing;
            bookings[count].RoomNo = booking.RoomNo;
            databaseEdit(bookings[count]);
        }
        public void databaseDel(Booking booking) {
            bookingDB.databaseDel(booking);
        }


        public void Delete(Booking booking) {
            int count = findIndex(booking);
            bookings.Remove(bookings[count]);
            databaseDel(booking);
        }
        #endregion

        #region lookups
        public int findIndex(Booking booking)
        {
            int index = 0;
            bool found = false;
            while (!found && index < bookings.Count)
            {
                found = bookings[index].BookingId == booking.BookingId;
                if (!found)
                {
                    index++;
                }

            }
            if (found)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        public Booking findById(string idValue)
        {
            int position = 0;
            bool found = (idValue == bookings[position].BookingId.ToString());
            while (!found && position < bookings.Count)
            {
                found = (idValue == bookings[position].BookingId.ToString());
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return bookings[position];
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
