using RestEasyApp.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyApp.Database
{
    public class BookingDB:DB
    {
        #region Fields
        private string table1 = "Bookings";
        private string sql_SELECT1 = "SELECT * FROM Bookings";
        private Collection<Booking> bookings;

        #endregion

        #region Constructor
        public BookingDB() : base()
        {
            bookings = new Collection<Booking>();
            readDataFromTable(sql_SELECT1,table1);
        }
        #endregion

        #region Property Methods
        public Collection<Booking> allBookings {
            get { return bookings; }
            set { bookings = value; }
        }
        #endregion

        #region Methods
        private void fillBookings(SqlDataReader reader, string dataTable, Collection<Booking> bookings) {
            Booking booking;
            while (reader.Read()) {
                booking = new Booking();
                booking.BookingId = reader.GetInt32(0);
                booking.Guestname = reader.GetString(1);
                booking.DateIn = reader.GetDateTime(2);
                booking.DateOut = reader.GetDateTime(3);
                booking.Pricing = reader.GetInt32(4);
                booking.RoomNo = reader.GetInt32(5);
                bookings.Add(booking);
            }
        }
        private string readDataFromTable(string selectString, string table)
        {
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
                    fillBookings(reader, table, bookings);
                }
                reader.Close();
                sqlConnection.Close();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion

        #region Crud
        private string getValueString(Booking b) {
            string str;
            str =b.BookingId + ", ' "+ b.Guestname.Trim()+ " ' , ' "+b.DateIn+ " ' ,"+
                " ' "+b.DateIn+ " ' ,"+
                " ' "+b.Pricing+ " ' ,"+
                " ' "+b.RoomNo+ " ' ";
            return str;
        }

        public void databaseAdd(Booking b) {
            string strSQL = "";
            strSQL = "INSERT into Bookings (Id , GuestName, dateIn, dateOut, Price, Room)" + " VALUES (" + getValueString(b) + ")";
            UpdateDataSource(new SqlCommand(strSQL, sqlConnection));
            Debug.WriteLine("Booking db database add called");
        }
        public void databaseEdit(Booking b) {
            string strSQL = "";
            strSQL = "Update Bookings set GuestName = '" + b.Guestname.Trim() + "' ," +
                "dateIn = '" + b.DateIn+"',"+
                "dateOut = '"+ b.DateOut+"',"+
                "Price = '"+ b.Pricing+"',"+
                "Room = '"+ b.RoomNo+"'"+
                "WHERE (Id = '"+b.BookingId+"')";
            UpdateDataSource(new SqlCommand(strSQL, sqlConnection));
        }

        public void databaseDel(Booking b) {
            string strSQL = "";
            strSQL = "Delete from Bookings WHERE Id = " + b.BookingId;
            UpdateDataSource(new SqlCommand(strSQL, sqlConnection));

        }
        #endregion
    }
}
