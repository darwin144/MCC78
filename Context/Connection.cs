using CRUD_Tugas_MCC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Context
{
    public abstract class Connection
    {
        protected string connectionString = "data source=DESKTOP-13OA1V1\\SQLEXPRESS; Database=db_Booking_Room; Integrated Security=true; TrustServerCertificate=true";

        public SqlConnection Connections() {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
