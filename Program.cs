using CRUD_Tugas_MCC.Model;
using CRUD_Tugas_MCC.Repository;

namespace CRUD_Tugas_MCC
{
    public class Program
    {
        private static readonly string[] menuUtama = { "1. Menu University", "2. Menu Education", "3. Insert  Data To Many Table", "4. Exit" };
        private static readonly string[] menuUniversity = {"1. Print All University","2. Print By Id", "3. Insert University","4. Update University","5. Delete University","0. Back to Main Menu"};
        private static readonly string[] menuEducation = {"1. Print All Education", "2. Print By Id", "3. Insert Education", "4. Update Education", "5. Delete Education", "0. Back to Main Menu" };

        static void Main(string[] args)
        {
            MenuUtama();

        }
        public static void MenuEducation()
        {
            Console.WriteLine("==============MENU UNIVERSITY============");
            Console.WriteLine("\n");
            PrintMenu(menuEducation);
            Console.Write("Masukkan Pilihan anda   : ");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    AppFunctions.PrintAllEducation();
                    MenuEducation();
                    break;
                case 2:
                    AppFunctions.PrintEducationById();
                    MenuEducation();
                    break;
                case 3:
                    AppFunctions.InsertEducation();
                    MenuEducation();
                    break;
                case 4:
                    AppFunctions.UpdateEducation();
                    MenuEducation();
                    break;
                case 5:
                    AppFunctions.DeleteEducation();
                    MenuEducation();
                    break;
                case 0:
                    MenuUtama();
                    break;
                default:
                    break;
            }
        }
        public static void MenuUniversity() {
            Console.WriteLine("\n==================================MENU UNIVERSITY==========================");
            Console.WriteLine("\n");
            PrintMenu(menuUniversity);
            Console.Write("Masukkan Pilihan anda   : ");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    AppFunctions.PrintAllUniversity();
                    MenuUniversity();
                    break;
                case 2:
                    AppFunctions.PrintUniversityById();
                    MenuUniversity();
                    break;
                case 3:
                    AppFunctions.InsertUniversity();
                    MenuUniversity();
                    break;
                case 4:
                    AppFunctions.UpdateUniversity();
                    MenuUniversity();
                    break;
                case 5:
                    AppFunctions.DeleteUniversity();
                    MenuUniversity();
                    break;
                case 0:
                    MenuUtama();
                    break;
                default:
                    break;
            }
        }
        public static void MenuUtama()
        {
            Console.WriteLine("==============================MENU UTAMA===============================");
            Console.WriteLine(" ");
            PrintMenu(menuUtama);
            Console.Write("Masukkan Menu Pilihan anda   : ");
            int input = AppFunctions.ValidationInt(Console.ReadLine());
            switch (input)
            {
                case 1:
                    MenuUniversity();
                    MenuUtama();
                    break;
                case 2:
                    MenuEducation();
                    MenuUtama();
                    break;
                case 3:
                    AppFunctions.InsertManyTable();
                    MenuUtama();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"Input salah. Masukkan angka 1 - {menuUtama.Length}");
                    MenuUtama();
                    break;
            }
        }
        public static void PrintMenu(string[] menu)
        {
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}