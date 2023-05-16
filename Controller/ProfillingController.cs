using CRUD_Tugas_MCC.Model;
using CRUD_Tugas_MCC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Controller
{
    public class ProfillingController
    {
        private Profilling profilling = new Profilling();
        public void insert(Profilling profilling)
        {
            var result = profilling.Insert(profilling);
            if (result == "success")
            {
                Console.WriteLine("Insert Data Success");
            }
            else
            {
                Console.WriteLine("Insert Data Gagal");
            }
        }
      

    }
}
