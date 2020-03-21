using RestEasyApp.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyApp.Entities
{
    public class RoomController
    {
        #region Data Fields
        
        private Collection<Booking> bookings;
        private BookingController bookingController;
        private Collection<Room> occupiedRooms;
        #endregion

        #region Constructor
        public RoomController(BookingController controller)
        {
            
            bookingController = controller;
            bookings = bookingController.allBookings;
        }
        #endregion

        #region Property Methods
        
        #endregion

        #region Method
       
        #endregion

        #region Methods
        public Collection<Room> occupiedList(DateTime date) {
            Room r;
            occupiedRooms = new Collection<Room>();
            foreach (Booking b in bookings) {
                if (b.DateIn<=date && date<= b.DateOut) {
                    r = new Room(b.RoomNo,false);
                    r.getGuest = b.Guestname;
                    r.getSignIn = b.DateIn;
                    r.getSignOut = b.DateOut;
                    occupiedRooms.Add(r);
                }
            }
            return occupiedRooms;
        }
        #endregion
    }
}
