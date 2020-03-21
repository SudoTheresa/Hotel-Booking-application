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
    public class Booking
    {
        #region DataFields
        private DateTime dateIn;
        private DateTime dateOut;
        private int roomNo;
        private string guestName;
        private double fprice;
        private double noDays;
        private int price;
        private int bookingId;
        private Collection<Room> rooms= new Collection<Room>() { new Room(1,true), new Room(2, true), new Room(3, true), new Room(4, true), new Room(5, true)};
        private enum Price {
            low = 550,
            mid = 750,
            high = 995,
            norm = 500
        };
        #endregion

        #region Constructor
        public Booking()
        {
            
        }
        #endregion

        #region Property methods
        public double fPricing {
            get { return fprice; }
            set { fprice = value; }
        }
        public int Pricing
        {
            get { return price; }
            set { price = value; }
        }
        public int BookingId {
            get { return bookingId; }
            set { bookingId = value; }
        }

        public int RoomNo {
            get { return roomNo; }
            set { roomNo = value; }
        }

        public string Guestname {
            get { return guestName; }
            set { guestName = value; }
        }
        public DateTime DateIn {
            get { return dateIn; }
            set { dateIn = value; }
        }

        public DateTime DateOut
        {
            get { return dateOut; }
            set { dateOut = value; }
        }

        public Collection<Room> getRooms {
            get { return rooms; }
        }

        #endregion

        #region Methods
        private void calFPrice() {
            fprice = price * numberofDays();
        }
        public double numberofDays()
        {
            noDays = dateOut.Subtract(dateIn).TotalDays;
            return noDays;
        }
        public void pricing() {
            DateTime dc_1 = new DateTime(2019, 12, 1);
            DateTime dc_2 = new DateTime(2019, 12, 7);
            DateTime dc_3 = new DateTime(2019, 12, 8);
            DateTime dc_4 = new DateTime(2019, 12, 15);
            DateTime dc_5 = new DateTime(2019, 12, 16);
            DateTime dc_6 = new DateTime(2019, 12, 31);

            if (dc_1<=dateIn && dateIn<=dc_2 ) {
                price = (int)Price.low;
                calFPrice();
            }
            if (dc_3<=dateIn && dateIn<=dc_4) {
                price = (int)Price.mid;
                calFPrice();
            }
            if (dc_5 <= dateIn && dateIn <= dc_6)
            {
                price = (int)Price.high;
                calFPrice();
            }
            else {
                price = (int)Price.norm;
                calFPrice();
            }
        }

        public bool qualify() {
            bool qualified = false;
            foreach (Room room in rooms) {
                Debug.WriteLine("Room availability "+ room.isAvailable(dateIn, dateOut));
                qualified = room.isAvailable(dateIn,dateOut);
                
                if (qualified) {
                    
                    return qualified;
                }
            }
            return qualified;
        }
        public void book() {
            foreach (Room room in rooms) {
                if (room.isAvailable(dateIn,dateOut)) {
                    roomNo = room.getId;
                    room.getSignIn = dateIn;
                    room.getSignIn = dateOut;
                    room.getAvailability = false;
                }
            }
           
        }

        
        #endregion
    }
}
