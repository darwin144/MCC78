using CRUD_Tugas_MCC.Abstract;
using CRUD_Tugas_MCC.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.View
{
    /*public static class AppFunctions
    {
        private static readonly ICRUD<List<University>, University> university = new University();
        private static readonly ICRUD<List<Education>, Education> education = new Education();
        private static readonly Employee employees = new Employee();
        private static readonly Profilling profilling = new Profilling();
        //private static object profillingy;

        *//*public static void PrintAllLINQ()
        {
            var Alldata = from e in employees.GetAll()
                          join p in profilling.GetAll() on e.Id equals p.EmployeeId
                          join edu in education.GetAll() on p.EducationId equals edu.Id
                          join u in university.GetAll() on edu.IdUniversity equals u.IdUniversity
                          select new
                          {
                              e.NIK,
                              FullName = string.Concat(e.FirstName, " ", e.LastName),
                              e.Birthdate,
                              e.Gender,
                              e.HiringDate,
                              e.Email,
                              e.PhoneNumber,
                              edu.Major,
                              edu.Degree,
                              edu.GPA,
                              UniversityName = u.Name
                          };

            // dengan method
            var getEmployee = employees.GetAll().Join(profilling.GetAll(), employeex => employeex.Id,
                profillingx => profillingx.EmployeeId, (employeex, profillingx) => new { employeex, profillingx }
             ).Join(education.GetAll(), profillingy => profillingy.profillingx.EducationId,
                educationx => educationx.Id, (profillingy, educationx) => new
                {
                    profillingy.employeex,
                    profillingy.profillingx,
                    educationx
                }
             ).Join(university.GetAll(), finalJoin => finalJoin.educationx.IdUniversity,
                    universitas => universitas.IdUniversity, (finalJoin, universitas) => new
                    {
                        finalJoin.employeex,
                        finalJoin.profillingx,
                        finalJoin.educationx,
                        universitas
                    }
             ).Select(finalJoin => new
             {
                 finalJoin.employeex.NIK,
                 FullName = string.Concat(finalJoin.employeex.FirstName, " ", finalJoin.employeex.LastName),
                 finalJoin.employeex.Birthdate,
                 finalJoin.employeex.Gender,
                 finalJoin.employeex.HiringDate,
                 finalJoin.employeex.Email,
                 finalJoin.employeex.PhoneNumber,
                 finalJoin.educationx.Major,
                 finalJoin.educationx.Degree,
                 finalJoin.educationx.GPA,
                 UniversityName = finalJoin.universitas.Name
             }).ToList();


            Console.WriteLine($"Total Employee:  {getEmployee.Count()}");
            int i = 1;
            foreach (var data in getEmployee)
            {
                Console.WriteLine($"\nData {i} ");
                Console.WriteLine($"NIK         : {data.NIK}");
                Console.WriteLine($"FulName     : {data.FullName}");
                Console.WriteLine($"Birthdate   : {data.Birthdate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"))}");
                Console.WriteLine($"Gender      : {data.Gender}");
                Console.WriteLine($"Hiring Date : {data.HiringDate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"))}");
                Console.WriteLine($"Email       : {data.Email}");
                Console.WriteLine($"Phone Number: {data.PhoneNumber}");
                Console.WriteLine($"Major       : {data.Major}");
                Console.WriteLine($"Degree      : {data.Degree}");
                Console.WriteLine($"GPA         : {data.GPA}");
                Console.WriteLine($"Nama Universitas  : {data.UniversityName}");
                i += 1;
            }

        }
       *//*
        public static int ValidationInt(string input)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(input);
                return result;
            }
            catch
            {
                Console.WriteLine("Input Salah Masukkan Hanya Angka !");
                Console.Write("Masukkan Pilihan Angka : ");
                result = ValidationInt(Console.ReadLine());
            }
            return result;
        }
        public static void InsertManyTable()
        {
            Console.WriteLine("****************** TOUCH MANY TABLE ***********************\n");
            Console.Write("Masukkan NIK                                    :");
            string nik = Console.ReadLine();
            Console.Write("Masukkan Firstname                              :");
            string firstName = Console.ReadLine();
            Console.Write("Masukkan Lastname                               :");
            string lastName = Console.ReadLine();
            Console.Write("Masukkan Birthdate. Format(Tahun,Bulan,Tanggal) :");
            DateTime birthdate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Gender (Male/Female)                    :");
            string gender = Console.ReadLine();
            Console.Write("Masukkan Hiring Date. Format(Tahun,Bulan,Tanggal):");
            DateTime hiringDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Masukkan Email                                   :");
            string email = Console.ReadLine();
            Console.Write("Masukkan Phone Number                            :");
            string phoneNumber = Console.ReadLine();
            Console.Write("Masukkan DepartmentId                            :");
            string departmentId = Console.ReadLine();
            Console.Write("Masukkan Major                                   :");
            string major = Console.ReadLine();
            Console.Write("Masukkan Degree                                  :");
            string degree = Console.ReadLine();
            Console.Write("Masukkan GPA                                     :");
            string gpa = Console.ReadLine();
            Console.Write("Masukkan Name University                         :");
            string universityName = Console.ReadLine();

            *//*string nik = "1123456";
            string firstName = "darwin";
            string lastName = "manurung";
            DateTime birthdate = new DateTime(1998, 5, 1);
            string gender = "male";
            DateTime hiringDate = new DateTime(2023,5,1);
            string email = "darwinx@gmail";
            string phoneNumber = "090988090";
            string departmentId = "001";
            string major = "Teknik Informatika";
            string degree ="S1";
            string gpa = "3.5";
            string universityName ="Universitas Riau";*//*

            try
            {
                ICRUD<List<Employee>, Employee> employee = new Employee();
                ICRUD<List<Profilling>, Profilling> profilling = new Profilling();

                Employee employeeInput = new Employee(nik, firstName, lastName, birthdate, gender, hiringDate, email, phoneNumber, departmentId);
                University universityInput = new University(universityName);
                int idUniversity = universityInput.GetIdUniversity();
                Education educationInput = new Education(major, degree, gpa, idUniversity);

                employee.Insert(employeeInput);
                university.Insert(universityInput);
                education.Insert(educationInput);

                Guid IdEmployee = Guid.Parse(employeeInput.GetIdEmployee(nik));
                int IdEducation = educationInput.GetIdEducation();
                Profilling profillingInput = new Profilling(IdEmployee, IdEducation);

                profilling.Insert(profillingInput);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
      *//*  public static void PrintAllEmployee()
        {

            var allEmployee = employees.GetAll();
            Console.WriteLine(" ");
            foreach (var data in allEmployee)
            {
                Console.WriteLine("");
                Console.WriteLine($"Id            : {data.Id}");
                Console.WriteLine($"NIK           : {data.NIK}");
                Console.WriteLine($"First Name    : {data.FirstName}");
                Console.WriteLine($"Last Name     : {data.LastName}");
                Console.WriteLine($"Birthdate     : {data.Birthdate}");
                Console.WriteLine($"Gender        : {data.Gender}");
                Console.WriteLine($"Hiring Date   : {data.HiringDate}");
                Console.WriteLine($"Email         : {data.Email}");
                Console.WriteLine($"Phone Number  : {data.PhoneNumber}");
                Console.WriteLine($"Department Id : {data.DepartmentId}");
            }
        }
      *//* 
        
        public static void PrintAllUniversity()
        {

            var allUniversity = university.GetAll();
            Console.WriteLine(" ");
            foreach (var data in allUniversity)
            {
                Console.WriteLine($"Id : {data.IdUniversity}");
                Console.WriteLine($"Name : {data.Name}");
            }
        }
        public static void PrintUniversityById()
        {
            Console.WriteLine("Masukkan Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var universityResult = university.GetById(id);
            Console.WriteLine($"Id : {universityResult.IdUniversity}");
            Console.WriteLine($"Name : {universityResult.Name}");
        }
        public static void PrintAllEducation()
        {
            int nomor = 1;
            var educations = education.GetAll();
            foreach (var education1 in educations)
            {
                Console.WriteLine($"Number {nomor}");
                Console.WriteLine($"Id            :{education1.Id}");
                Console.WriteLine($"Major         :{education1.Major}");
                Console.WriteLine($"Degree        :{education1.Degree}");
                Console.WriteLine($"GPA           : {education1.GPA}");
                Console.WriteLine($"Id university :{education1.IdUniversity}");
                nomor += 1;
            }
        }
        public static void PrintEducationById()
        {

            Console.Write("Masukkan Id Education : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var educationResult = education.GetById(id);
            Console.WriteLine("\n");
            Console.WriteLine($"Id            :{educationResult.Id}");
            Console.WriteLine($"Major         :{educationResult.Major}");
            Console.WriteLine($"Degree        :{educationResult.Degree}");
            Console.WriteLine($"GPA           : {educationResult.GPA}");
            Console.WriteLine($"Id university :{educationResult.IdUniversity}");
        }
        public static void InsertEducation()
        {
            Console.WriteLine("***************INSERT EDUCATION*************");
            Console.Write("Masukkan Major         : ");
            string major = Console.ReadLine();
            Console.Write("Masukkan Degree        : ");
            string degree = Console.ReadLine();
            Console.Write("Masukkan GPA           : ");
            string gpa = Console.ReadLine();
            Console.Write("Masukkan ID University : ");
            int universityId = Convert.ToInt32(Console.ReadLine());

            Education education1 = new Education(major, degree, gpa, universityId);
            education.Insert(education1);

        }
        public static void UpdateEducation()
        {
            Console.WriteLine("****************ALL Education***************");
            PrintAllEducation();
            Console.WriteLine("***************UPDATE EDUCATION*************");
            Console.Write("Masukkan ID         : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Major         : ");
            string major = Console.ReadLine();
            Console.Write("Masukkan Degree        : ");
            string degree = Console.ReadLine();
            Console.Write("Masukkan GPA           : ");
            string gpa = Console.ReadLine();
            Console.Write("Masukkan ID University : ");
            int universityId = Convert.ToInt32(Console.ReadLine());
            Education education1 = new Education(id, major, degree, gpa, universityId);
            education.Update(education1);

        }
        public static void DeleteEducation()
        {
            Console.WriteLine("******************DELETE EDUCATION****************\n");
            Console.Write("Masukkan Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            education.Delete(id);
        }
        public static void InsertUniversity()
        {
            Console.WriteLine("*********************INSERT UNIVERSITY***********************");
            Console.WriteLine("Masukkan Nama University : ");
            string nama = Console.ReadLine();
            var university = new University(nama);
            university.Insert(university);
        }
        public static void UpdateUniversity()
        {
            Console.WriteLine("******************ALL UNIVERSITY**********************");
            PrintAllUniversity();
            Console.WriteLine("*********************UPDATE UNIVERSITY***********************");
            Console.Write("Masukkan ID University : ");
            int idUniversity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Baru University : ");
            string name = Console.ReadLine();
            var university1 = new University(idUniversity, name);
            university.Update(university1);
        }
        public static void DeleteUniversity()
        {
            Console.WriteLine("*********************DELETE UNIVERSITY***********************");
            Console.WriteLine("Masukkan ID University : ");
            int idUniversity = Convert.ToInt32(Console.ReadLine());
            university.Delete(idUniversity);
        }
    }*/
}
