using CRUD_Tugas_MCC.Abstract;
using CRUD_Tugas_MCC.Controller;
using CRUD_Tugas_MCC.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.View
{

    public class MenuView
    {

        private  readonly string[] menuUtama = { "1. Menu University", "2. Menu Education", "3. Insert  Data To Many Table", "4. All Employee", "5. ALL Data LINQ ", "6. Exit" };
        private  readonly string[] menuUniversity = { "1. Print All University", "2. Print By Id", "3. Insert University", "4. Update University", "5. Delete University", "0. Back to Main Menu" };
        private  readonly string[] menuEducation = { "1. Print All Education", "2. Print By Id", "3. Insert Education", "4. Update Education", "5. Delete Education", "0. Back to Main Menu" };

        private readonly MenuController _menu = new MenuController();
        private readonly EmployeeController _employeeController = new EmployeeController();
        private readonly EducationController _educationController = new EducationController();
        private readonly UniversityController _universityController = new UniversityController();
        private readonly ProfillingController _profillingController = new ProfillingController();
     

        public void MenuUtama()
        {
            Console.WriteLine("==============================MENU UTAMA===============================");
            Console.WriteLine(" ");
            PrintMenu(menuUtama);
            
            _menu.PilihMenuUtama();

        }

        public void PrintMenu(string[] menu)
        {
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
        }
        public void MenuEducation()
        {
            Console.WriteLine("==============MENU EDUCATION============");
            Console.WriteLine("\n");
            PrintMenu(menuEducation);
            Console.Write("masukkan Pilihan :");
            int input = Convert.ToInt32(Console.ReadLine());

            _educationController.MenuEducation(input);
          
        }
        
        public void MenuUniversity()
        {
            Console.WriteLine("\n==================================MENU UNIVERSITY==========================");
            Console.WriteLine("\n");
            PrintMenu(menuUniversity);

            Console.Write("masukkan Pilihan :");
            int input = Convert.ToInt32(Console.ReadLine());
            _universityController.MenuUniversity(input);
            
        }
               
        public void InsertManyTable()
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

            /*string nik = "1123456";
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
            string universityName ="Universitas Riau";*/

            try
            {
                
                Profilling profilling = new Profilling();
                Employee employeeInput = new Employee(nik, firstName, lastName, birthdate, gender, hiringDate, email, phoneNumber, departmentId);
                University universityInput = new University(universityName);
                int idUniversity = universityInput.GetIdUniversity();
                Education educationInput = new Education(major, degree, gpa, idUniversity);

                // mapping data object
                _employeeController.insert(employeeInput);
                _universityController.insert(universityName);
                _educationController.insert(educationInput);
                
                Guid IdEmployee = Guid.Parse(employeeInput.GetIdEmployee(nik));
                int IdEducation = educationInput.GetIdEducation();
                Profilling profillingInput = new Profilling(IdEmployee, IdEducation);
                _profillingController.insert(profillingInput);               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
