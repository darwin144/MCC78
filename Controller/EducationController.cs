using CRUD_Tugas_MCC.Abstract;
using CRUD_Tugas_MCC.Model;
using CRUD_Tugas_MCC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Controller
{
    public class EducationController
    {
        private ICRUD<List<Education>, Education> _education = new Education();

        public void MenuEducation(int input)
        {

            MenuView view = new MenuView();
            EducationView educationView = new EducationView();
            EducationController educationController = new EducationController();
            switch (input)
            {
                case 1:
                    GetAll();
                    view.MenuEducation();
                    break;
                case 2:
                    GetbById();
                    view.MenuEducation();
                    break;
                case 3:
                    educationView.Insert();
                    view.MenuEducation();
                    break;
                case 4:
                    educationView.Update();
                    view.MenuEducation();
                    break;
                case 5:
                    educationView.Delete();
                    view.MenuEducation();
                    break;
                case 0:
                    view.MenuUtama();
                    break;
                default:
                    break;
            }

        }
        public void GetAll()
        {
            var result = _education.GetAll();
            var viewEducation = new EducationView();
            viewEducation.Output(result);
        }
        public void GetbById()
        {
            Console.Write("Masukkan Id University : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = _education.GetById(id);
            var view = new EducationView();
            view.Output(result);
        }
        public void insert(Education education)
        {
            var result = _education.Insert(education);
            if (result == "success")
            {
                Console.WriteLine("Insert Data Success");
            }
            else
            {
                Console.WriteLine("Insert Data Gagal");
            }
        }
        public void Delete(int id)
        {
            var result = _education.Delete(id);
            if (result == "success")
            {
                Console.WriteLine("Delete Data Success");
            }
            else
            {
                Console.WriteLine("Delete Data Gagal");
            }

        }
        public void Update(Education education)
        {
            var result = _education.Insert(education);
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
