﻿using CRUD_Tugas_MCC.Abstract;
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
    public class Education : University, ICRUD<List<Education>, Education>
    {
        public int Id { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }

        public Education() { }
        public Education(int id,string major, string degree, string gPA, int universityId)
        : base(universityId)
        {
            Id = id;
            Major = major;
            Degree = degree;
            GPA = gPA;
        }
        public Education( string major, string degree, string gPA, int universityId)
        : base(universityId)
        {
            Major = major;
            Degree = degree;
            GPA = gPA;
        }

        public List<Education> GetAll()
        {
            List<Education> Educations = new List<Education>();
            

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var education = new Education();
                        education.Id = reader.GetInt32(0);
                        education.Major = reader.GetString(1);
                        education.Degree = reader.GetString(2);
                        education.GPA = reader.GetString(3);
                        education.IdUniversity = reader.GetInt32(4);

                        Educations.Add(education);
                    }
                    return Educations;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally {
                connection.Close();
            }
            return Educations;
        }

        public Education GetById(int id)
        {
            Education education = new Education();
            using SqlConnection connection = new SqlConnection(base.connectionString);
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations WHERE id =@id";

                SqlParameter Pid = new SqlParameter();
                Pid.ParameterName = "@id";
                Pid.SqlDbType = SqlDbType.Int;
                Pid.Value = id;
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    education.Id = reader.GetInt32(0);
                    education.Major = reader.GetString(1);
                    education.Degree = reader.GetString(2);
                    education.GPA = reader.GetString(3);
                    education.IdUniversity = reader.GetInt32(4);
                    return education;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return education;
        }

        public int GetIdEducation() {
            int result = 0;
            Education education = new Education();
            using SqlConnection connection = new SqlConnection(base.connectionString);
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT TOP 1 Id FROM tb_m_educations ORDER BY Id DESC";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    education.Id = reader.GetInt32(0);
                    result = education.Id;
                    return result;
                }
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

        public string Insert(Education education)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(base.connectionString);
            connection.Open();

            try
            {
                using SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_educations(major,degree,gpa,university_id) VALUES (@major,@degree,@gpa, @universityId)";
                command.Transaction = transaction;

                SqlParameter Pmajor = new SqlParameter();
                Pmajor.ParameterName = "@major";
                Pmajor.SqlDbType = SqlDbType.VarChar;
                Pmajor.Value = education.Major;
                command.Parameters.Add(Pmajor);

                SqlParameter Pdegree = new SqlParameter();
                Pdegree.ParameterName = "@degree";
                Pdegree.SqlDbType = SqlDbType.VarChar;
                Pdegree.Value = education.Degree;
                command.Parameters.Add(Pdegree);

                SqlParameter Pgpa = new SqlParameter();
                Pgpa.ParameterName = "@gpa";
                Pgpa.SqlDbType = SqlDbType.VarChar;
                Pgpa.Value = education.GPA;
                command.Parameters.Add(Pgpa);

                SqlParameter PuniversityId = new SqlParameter();
                PuniversityId.ParameterName = "@universityId";
                PuniversityId.SqlDbType = SqlDbType.Int;
                PuniversityId.Value = education.IdUniversity;
                command.Parameters.Add(PuniversityId);

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

        public void Insert2(Education education)
        {
            SqlConnection connection = new SqlConnection(base.connectionString);
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                //using SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_educations(major,degree,gpa,university_id) VALUES (@major,@degree,@gpa, @universityId)";
                command.Transaction = transaction;

                SqlParameter Pmajor = new SqlParameter();
                Pmajor.ParameterName = "@major";
                Pmajor.SqlDbType = SqlDbType.VarChar;
                Pmajor.Value = education.Major;
                command.Parameters.Add(Pmajor);

                SqlParameter Pdegree = new SqlParameter();
                Pdegree.ParameterName = "@degree";
                Pdegree.SqlDbType = SqlDbType.VarChar;
                Pdegree.Value = education.Degree;
                command.Parameters.Add(Pdegree);

                SqlParameter Pgpa = new SqlParameter();
                Pgpa.ParameterName = "@gpa";
                Pgpa.SqlDbType = SqlDbType.VarChar;
                Pgpa.Value = education.GPA;
                command.Parameters.Add(Pgpa);

                SqlParameter PuniversityId = new SqlParameter();
                PuniversityId.ParameterName = "@universityId";
                PuniversityId.SqlDbType = SqlDbType.Int;
                PuniversityId.Value = education.IdUniversity;
                command.Parameters.Add(PuniversityId);

                command.ExecuteNonQuery();
                //transaction.Commit();

                Console.WriteLine("Inserted Success");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }
           /* finally
            {
                connection.Close();
            }*/
        }

        public string Update(Education education)
        {
            string result = "";
            SqlConnection connection = new SqlConnection();
            connection.Open();

            try
            {
                using SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE FROM tb_m_educations SET major = @major,degree = @degree,gpa = @gpa, universityId = @universityId WHERE Id = @id";
                command.Transaction = transaction;

                SqlParameter Pid = new SqlParameter();
                Pid.ParameterName = "@id";
                Pid.SqlDbType = SqlDbType.VarChar;
                Pid.Value = education.Id;
                command.Parameters.Add(Pid);

                SqlParameter Pmajor = new SqlParameter();
                Pmajor.ParameterName = "@major";
                Pmajor.SqlDbType = SqlDbType.VarChar;
                Pmajor.Value = education.Major;
                command.Parameters.Add(Pmajor);

                SqlParameter Pdegree = new SqlParameter();
                Pdegree.ParameterName = "@degree";
                Pdegree.SqlDbType = SqlDbType.VarChar;
                Pdegree.Value = education.Degree;
                command.Parameters.Add(Pdegree);

                SqlParameter Pgpa = new SqlParameter();
                Pgpa.ParameterName = "@gpa";
                Pgpa.SqlDbType = SqlDbType.VarChar;
                Pgpa.Value = education.GPA;
                command.Parameters.Add(Pgpa);

                SqlParameter PuniversityId = new SqlParameter();
                PuniversityId.ParameterName = "@universityId";
                PuniversityId.SqlDbType = SqlDbType.VarChar;
                PuniversityId.Value = education.IdUniversity;
                command.Parameters.Add(PuniversityId);

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
            var connection = Connections();
            try
            {
                using SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_educations WHERE Id = @id";
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
