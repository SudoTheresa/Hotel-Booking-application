using RestEasyApp.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyApp.Entities
{
    public class GuestController
    {
        #region Fields
        GuestDB guestDB;
        private Collection<Guest> guests;
        #endregion

        #region Constructor
        public GuestController() {
            guestDB = new GuestDB();
            guests = guestDB.allGuests;
        }
        #endregion

        #region Getter
        public Collection<Guest>AllGuests{
            get{return guests;}
        }
        #endregion

        #region CRUD 
        public void databaseAdd(Guest guest) {
            guestDB.databaseAdd(guest);
        }
        public void Add(Guest g) {
            databaseAdd(g);
            guests.Add(g);
        }
        public void databaseEdit(Guest g) {
            guestDB.databaseEdit(g);

        }
        public void Edit(Guest g) {
            int count = findIndex(g);
            guests[count].Name = g.Name;
            guests[count].InHotel = g.InHotel;
            guests[count].daysBooked = g.daysBooked;
            guests[count].Address = g.Address;
            guests[count].CreditCardDetails = g.CreditCardDetails;
            databaseEdit(guests[count]);
        }
        #endregion

        #region Lookups
        public int findIndex(Guest guest) {
            int index = 0;
            bool found = false;
            while (!found && index < guests.Count ) {
                found = guests[index].guestID == guest.guestID;
                if (!found) {
                    index++;
                }
               
            }
            if (found)
            {
                return index;
            }
            else{
                return -1;
            }
        }

        public Guest findById(string idValue) {
            int position = 0;
            bool found = (idValue == guests[position].guestID.ToString());
            while (!found && position < guests.Count)
            {
                found = (idValue == guests[position].guestID.ToString());
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return guests[position];
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
