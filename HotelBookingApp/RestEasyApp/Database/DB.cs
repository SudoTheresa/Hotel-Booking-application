using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RestEasyApp.Properties;

namespace RestEasyApp.Database
{
    public class DB
    {
        #region
        private string strConn = Settings.Default.Database1ConnectionString;
        //private string strConn;
        protected SqlConnection sqlConnection;
        #endregion

        #region Constructor
        public DB()
        {
            try
            {
                sqlConnection = new SqlConnection(strConn);
            }
            catch (SystemException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error in Making a Connection");
                return;
            }
        }
        #endregion

        #region Methods
        public Boolean UpdateDataSource(SqlCommand currentCommand)
        {
            sqlConnection.Close();//added for debugging
            Boolean success;
            try
            {
                sqlConnection.Open();
                currentCommand.CommandType = CommandType.Text;
                currentCommand.ExecuteNonQuery();
                sqlConnection.Close();
                success = true;
            }
            catch (Exception errObj)
            {
                System.Windows.Forms.MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;
            }
            finally { }

            return success;
        }
        #endregion
    }
}
