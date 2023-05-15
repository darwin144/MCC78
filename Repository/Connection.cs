using CRUD_Tugas_MCC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Repository
{
    public abstract class Connection
    {
        protected string connectionString = "data source=DESKTOP-13OA1V1\\SQLEXPRESS; Database=db_Booking_Room; Integrated Security=true; TrustServerCertificate=true";

        

    }
}
