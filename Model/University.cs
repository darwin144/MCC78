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
    public class University : Connection
    {
        public int IdUniversity { get; set; }
        public string Name { get; set; }

        public University() { }

        public University(int idUniversity, string name)
        {
            IdUniversity = idUniversity;
            Name = name;
        }
        public University(int id)
        {
            IdUniversity = id;
        }
        public University(string name)
        {
            Name = name;
        }

        public List<University> GetAll()
        {
            List<University> Universities = new List<University>();
           
            try
            {
                using SqlConnection connection = new SqlConnection(base.connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_Universities";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        University university = new University();
                        university.IdUniversity = reader.GetInt32(0);
                        university.Name = reader.GetString(1);

                        Universities.Add(university);
                    }
                    return Universities;
                }
            }
            catch
            {
            }
            return Universities;
        }

        public University GetById(int id)
        {
            University university = new University();            
            using SqlConnection connection = new SqlConnection(base.connectionString);
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_Universities WHERE id= @id";

                SqlParameter Pid = new SqlParameter();
                Pid.ParameterName = "@id";
                Pid.SqlDbType = SqlDbType.Int;
                Pid.Value = id;
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    university.IdUniversity = reader.GetInt32(0);
                    university.Name = reader.GetString(1);

                    return university;
                }
            }
            catch { 
            
            }

            return university;
        }
        public int GetIdUniversity() {
            int result = 0;
            University university = new University();
            using SqlConnection connection = new SqlConnection(base.connectionString);
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT TOP 1 Id FROM tb_m_Universities ORDER BY id DESC";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    university.IdUniversity = reader.GetInt32(0);
                    return university.IdUniversity;
                }
            }
            catch
            {

            }
            return result;
        }
        public string Insert(string name)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                using SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_universities VALUES(@name)";
                command.Transaction = transaction;

                SqlParameter Pname = new SqlParameter();
                Pname.ParameterName = "@name";
                Pname.SqlDbType = SqlDbType.VarChar;
                Pname.Value = name;
                command.Parameters.Add(Pname);

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

        public string Update(int id, string input)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                using SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_universities SET Name = @name WHERE Id = @id";
                command.Transaction = transaction;

                SqlParameter Pid = new SqlParameter();
                Pid.ParameterName = "@id";
                Pid.SqlDbType = SqlDbType.VarChar;
                Pid.Value = id;

                SqlParameter Pname = new SqlParameter();
                Pname.ParameterName = "@name";
                Pname.SqlDbType = SqlDbType.VarChar;
                Pname.Value = input;

                command.Parameters.Add(Pid);
                command.Parameters.Add(Pname);

                command.ExecuteNonQuery();
                transaction.Commit();
                result = "success";
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public string Delete(int id)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                using SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_universities WHERE Id = @id";
                command.Transaction = transaction;

                SqlParameter Pid = new SqlParameter();
                Pid.ParameterName = "@id";
                Pid.SqlDbType = SqlDbType.VarChar;
                Pid.Value = id;

                command.Parameters.Add(Pid);
                command.ExecuteNonQuery();
                transaction.Commit();

                result = "success";
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }

}
