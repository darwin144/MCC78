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
    public class EmployeeController
    {
        private readonly ICRUD<List<Employee>,Employee> _employee = new Employee();
        public void GetAll()
        {
            var result = _employee.GetAll();
            var view = new EmployeeView();
            if (result != null)
            {
                view.Output(result);
            }
            else {
                Console.WriteLine("Data Kosong");
            }
        }
        public void GetbById(int id)
        {

            var result = _employee.GetById(id);
            var view = new EmployeeView();
            if (result != null)
            {
                view.Output(result);
            }
            else
            {
                Console.WriteLine("Data Kosong");
            }
            
        }
        public void insert(Employee employee)
        {
            var result = _employee.Insert(employee);
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
            var result = _employee.Delete(id);
            if (result == "success")
            {
                Console.WriteLine("Delete Data Success");
            }
            else
            {
                Console.WriteLine("Delete Data Gagal");
            }

        }
        public void Update(Employee employee)
        {
            var result = _employee.Update(employee);
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
