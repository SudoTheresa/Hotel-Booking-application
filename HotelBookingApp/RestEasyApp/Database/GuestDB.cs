using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyApp.Database
{
    public class GuestDB:DB
    {
        #region Fields
        private string table1 = "Guests";
        private string sql_SELECT1 = "SELECT * FROM Guests";
        private Collection<Guest> guests;
        #endregion

        #region Constructor
        public GuestDB() : base() {
            guests = new Collection<Guest>();
            readDataFromTable(sql_SELECT1, table1);
        }
        #endregion

        #region Getter
        public Collection<Guest> allGuests{
            get{
                return guests;
            }
        }
        #endregion

        #region Methods
        private void fillGuests(SqlDataReader reader, string dataTable, Collection<Guest> guests) {
            Guest guest;
            while (reader.Read()) {
                guest = new Guest();
                guest.guestID = reader.GetInt32(0);
                guest.Name = reader.GetString(1).Trim();
                if (reader.GetString(2) == "True")
                {
                    guest.InHotel = true;
                }
                else {
                    guest.InHotel = false;
                }
                guest.daysBooked = reader.GetInt32(3);
                guest.Address = reader.GetString(4).Trim();
                guest.CreditCardDetails = reader.GetString(5).Trim();
                guests.Add(guest);
            }
        }

        private string readDataFromTable(string selectString, string table) {
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                command = new SqlCommand(selectString, sqlConnection);
                sqlConnection.Open();
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    fillGuests(reader, table, guests);
                }
                reader.Close();
                sqlConnection.Close();
                return "Success";
            }
            catch (Exception ex) {
                return ex.ToString();
            }
        }
        #endregion

        #region CRUD
        private string getValueString(Guest guestTemp) {
            string aStr;
            aStr = guestTemp.guestID + ", ' "+ guestTemp.Name + " ' , '" + guestTemp.InHotel.ToString() + " ' ," +
                " ' "+guestTemp.daysBooked + " ' ," + 
                " ' "+guestTemp.Address + " ' ," +
                " ' "+ guestTemp.CreditCardDetails + " ' ";
            return aStr;
        }
        public void databaseAdd(Guest guestTemp) {
            string strSQL = "";

            strSQL= "INSERT into Guests(GuestId, Name, inHotel, daysBooked, Address, creditCardDetails)" + " VALUES ("+ getValueString(guestTemp) + ")";

            UpdateDataSource(new SqlCommand(strSQL, sqlConnection));
        }

        public void databaseEdit(Guest guestTemp) {
            string strSQL = "";

            strSQL= "UPDATE Guests set Name = '"+guestTemp.Name+"',"+
                "inHotel = '"+guestTemp.InHotel.ToString()+"'," +
                "daysBooked = '"+guestTemp.daysBooked+"',"+
                "Address = '"+guestTemp.Address+"',"+
                "creditCardDetails = '"+guestTemp.CreditCardDetails+"'"+
                "WHERE (GuestId = '"+guestTemp.guestID+"')";

            UpdateDataSource(new SqlCommand(strSQL,sqlConnection));
        }
        #endregion
    }
}
