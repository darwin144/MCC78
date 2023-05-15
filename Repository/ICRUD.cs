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
        public void Insert(Tobject input);
        public void Update(Tobject input);
        public void Delete(int id);

    }
}
