using CRUD_Tugas_MCC.Abstract;
using CRUD_Tugas_MCC.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Model
{
    public class Profilling : Connection
    {
        public Guid EmployeeId { get; set; }
        public int EducationId { get; set; }

        public Profilling() { }
        public Profilling(Guid employeeId, int educationId)
        {
            EmployeeId = employeeId;
            EducationId = educationId;
        }

        public List<Profilling> GetAll()
        {
            List<Profilling> profillings = new List<Profilling>();

            try
            {
                using SqlConnection connection = new SqlConnection(base.connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_profillings";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Profilling profilling = new Profilling();
                        profilling.EmployeeId = reader.GetGuid(0);
                        profilling.EducationId = reader.GetInt32(1);
                        
                        profillings.Add(profilling);
                    }
                    return profillings;
                }
            }
            catch
            {
            }
            return profillings;
        }

        public Profilling GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string Insert(Profilling profilling)
        {
            string result = "";
            var connection = Connections();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_tr_profillings VALUES(@employeeId, @educationId)";
                command.Transaction = transaction;

                SqlParameter PemployeeId = new SqlParameter();
                PemployeeId.ParameterName = "@employeeId";
                PemployeeId.SqlDbType = SqlDbType.UniqueIdentifier;
                PemployeeId.Value = profilling.EmployeeId;
                command.Parameters.Add(PemployeeId);

                SqlParameter PeducationId = new SqlParameter();
                PeducationId.ParameterName = "@educationId";
                PeducationId.SqlDbType = SqlDbType.Int;
                PeducationId.Value = profilling.EducationId;
                command.Parameters.Add(PeducationId);

                command.ExecuteNonQuery();
                transaction.Commit();

                result = "success";
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally {
                connection.Close();
            }
            return result;

        }

    }
}
