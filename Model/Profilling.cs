using CRUD_Tugas_MCC.Abstract;
using CRUD_Tugas_MCC.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Model
{
    public class Profilling : Connection, ICRUD<List<Profilling>,Profilling>
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
            throw new NotImplementedException();
        }

        public Profilling GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Profilling profilling)
        {
            SqlConnection connection = new SqlConnection(base.connectionString);
            connection.Open();
            try
            {
                SqlTransaction transaction = connection.BeginTransaction();
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

                Console.WriteLine("Insert Profilling Succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        public void Update(Profilling input)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
