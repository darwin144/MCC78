using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
