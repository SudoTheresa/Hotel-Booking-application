using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyApp.Database
{
    public class Room
    {
        #region Fields
        private int id;
        private bool available;
        private string guest;
        private DateTime signIn;
        private DateTime signOut;
        private string comments;
        #endregion

        #region Constructors
        public Room(int id, bool available)
        {
            this.id = id;
            this.available = available;
            comments = "N/A";

        }
        #endregion

        #region Properties methods / Getters and Setters
        public int getId {
            get { return id; }
            set { id = value; }
        }

        public bool getAvailability {
            get { return available; }
            set { available = value; }
        }

        public string getGuest {
            get { return guest; }
            set { guest = value; }
        }

        public DateTime getSignIn {
            get { return signIn; }
            set { signIn = value; }
        }

        public DateTime getSignOut
        {
            get { return signOut; }
            set { signOut = value; }
        }

        public string getComments {
            get { return comments; }
            set { comments = value; }
        }
        #endregion

        #region Methods
        public bool isAvailable(DateTime dateIn, DateTime dateOut) {
            if ((dateIn <= signIn && dateOut <= signIn) || (dateIn >= signOut && dateOut >= signOut))
            {
                available = true;
            }
            else {
                available = false;
            }
            return available;
        }
        #endregion
    }
}
