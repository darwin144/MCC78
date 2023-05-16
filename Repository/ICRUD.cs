using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Abstract
{
    public interface ICRUD<Tall,Tobject>
    {
        public Tall GetAll();
        public Tobject GetById(int id);
        public string Insert(Tobject input);
        public string Update(Tobject input);
        public string Delete(int id);

    }
}
