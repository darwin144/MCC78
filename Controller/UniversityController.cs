using CRUD_Tugas_MCC.Model;
using CRUD_Tugas_MCC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Controller
{
    public class UniversityController
    {
        private University _university = new University();

        public void MenuUniversity(int input)
        {

            MenuView view = new MenuView();
            UniversityView universityView = new UniversityView();
            switch (input)
            {
                case 1:
                    GetAll();
                    view.MenuUniversity();
                    break;
                case 2:
                    GetbById();
                    view.MenuUniversity();
                    break;
                case 3:
                    universityView.Input();
                    view.MenuUniversity();
                    break;
                case 4:
                    universityView.Update();
                    view.MenuUniversity();
                    break;
                case 5:
                    universityView.Delete();
                    view.MenuUniversity();
                    break;
                case 0:
                    view.MenuUtama();
                    break;
                default:
                    break;
            }
        }

        public void GetAll() {
            var result  = _university.GetAll();
            var viewUniversity = new UniversityView();
            viewUniversity.Output(result);        
        }
        public void GetbById() {
            Console.WriteLine("Masukkan Id Universitas:");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = _university.GetById(id);
            var viewUniversity = new UniversityView();
            viewUniversity.Output(result);
        }
        public void insert(string nama) {            
            var result = _university.Insert(nama);
            if (result == "success")
            {
                Console.WriteLine("Insert Data Success");
            }
            else {
                Console.WriteLine("Insert Data Gagal");
            }
        }
        public void Delete(int id) {
            var result = _university.Delete(id);
            if (result == "success")
            {
                Console.WriteLine("Delete Data Success");
            }
            else
            {
                Console.WriteLine("Delete Data Gagal");
            }
         
        }
        public void Update(int id, string input) {
            var result = _university.Update(id, input);
            if (result == "success")
            {
                Console.WriteLine("Delete Data Success");
            }
            else
            {
                Console.WriteLine("Delete Data Gagal");
            }

        }
    }
}
