using CRUD_Tugas_MCC.Abstract;
using CRUD_Tugas_MCC.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Model
{
    public class Employee : Connection, ICRUD<List<Employee>,Employee>
    {

        public Guid Id { get; set; }
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentId { get; set; }

        public Employee() { }
        public Employee(string nIK, string firstName, string lastName, DateTime birthdate, string gender, DateTime hiringDate, string email, string phoneNumber, string departmentId)
        {            
            NIK = nIK;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
            HiringDate = hiringDate;
            Email = email;
            PhoneNumber = phoneNumber;
            DepartmentId = departmentId;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using SqlConnection connection = new SqlConnection(base.connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employees";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee1 = new Employee();
                        employee1.Id = reader.GetGuid(0);
                        employee1.NIK = reader.GetString(1);
                        employee1.FirstName = reader.GetString(2);
                        employee1.LastName = reader.GetString(3);
                        employee1.Birthdate = reader.GetDateTime(4);
                        employee1.Gender = reader.GetString(5);
                        employee1.HiringDate = reader.GetDateTime(6);
                        employee1.Email = reader.GetString(7);
                        employee1.PhoneNumber = reader.GetString(8);
                        employee1.DepartmentId = reader.GetString(9);


                        employees.Add(employee1);
                    }
                    return employees;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employees;
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }
        public string GetIdEmployee(string nik) {
            string result = "";
            Employee employee = new Employee();
            using SqlConnection connection = new SqlConnection(base.connectionString);
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Id FROM tb_m_employees WHERE nik = @nik";

                SqlParameter Pnik = new SqlParameter();
                Pnik.ParameterName = "@nik";
                Pnik.SqlDbType = SqlDbType.VarChar;
                Pnik.Value = nik;
                command.Parameters.Add(Pnik);

                using SqlDataReader reader = command.ExecuteReader();
                
                    reader.Read();
                    employee.Id = reader.GetGuid(0);
                    result = Convert.ToString(employee.Id);
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

        public string Insert(Employee employee)
        {
            string result = "";   
            string sql = "INSERT INTO tb_m_employees(nik, first_Name, last_Name, birthdate, gender, hiring_Date, email, phone_Number, department_Id) VALUES (@nik,@firstName,@lastName,@birthdate,@gender,@hiringDate, @email, @phoneNumber, @departmentId)";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //using SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = sql;
                command.Transaction = transaction;

                SqlParameter Pnik = new SqlParameter();
                Pnik.ParameterName = "@nik";
                Pnik.SqlDbType = SqlDbType.VarChar;
                Pnik.Value = employee.NIK;
                command.Parameters.Add(Pnik);

                SqlParameter Pfirstname = new SqlParameter();
                Pfirstname.ParameterName = "@firstName";
                Pfirstname.SqlDbType = SqlDbType.VarChar;
                Pfirstname.Value = employee.FirstName;
                command.Parameters.Add(Pfirstname);

                SqlParameter Plastname = new SqlParameter();
                Plastname.ParameterName = "@lastName";
                Plastname.SqlDbType = SqlDbType.VarChar;
                Plastname.Value = employee.LastName;
                command.Parameters.Add(Plastname);

                SqlParameter Pbirthdate = new SqlParameter();
                Pbirthdate.ParameterName = "@birthdate";
                Pbirthdate.SqlDbType = SqlDbType.DateTime;
                Pbirthdate.Value = employee.Birthdate;
                command.Parameters.Add(Pbirthdate);

                SqlParameter Pgender = new SqlParameter();
                Pgender.ParameterName = "@gender";
                Pgender.SqlDbType = SqlDbType.VarChar;
                Pgender.Value = employee.Gender;
                command.Parameters.Add(Pgender);

                SqlParameter PhiringDate = new SqlParameter();
                PhiringDate.ParameterName = "@hiringDate";
                PhiringDate.SqlDbType = SqlDbType.DateTime;
                PhiringDate.Value = employee.HiringDate;
                command.Parameters.Add(PhiringDate);

                SqlParameter Pemail = new SqlParameter();
                Pemail.ParameterName = "@email";
                Pemail.SqlDbType = SqlDbType.VarChar;
                Pemail.Value = employee.Email;
                command.Parameters.Add(Pemail);

                SqlParameter PphoneNumber = new SqlParameter();
                PphoneNumber.ParameterName = "@phoneNumber";
                PphoneNumber.SqlDbType = SqlDbType.VarChar;
                PphoneNumber.Value = employee.PhoneNumber;
                command.Parameters.Add(PphoneNumber);

                SqlParameter PdepartmentID = new SqlParameter();
                PdepartmentID.ParameterName = "@departmentId";
                PdepartmentID.SqlDbType = SqlDbType.VarChar;
                PdepartmentID.Value = employee.DepartmentId;
                command.Parameters.Add(PdepartmentID);

                command.ExecuteNonQuery();
                transaction.Commit();

                result = "success";
                return result;
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public string Update(Employee input)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
