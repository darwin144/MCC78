using CRUD_Tugas_MCC.Model;
using CRUD_Tugas_MCC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Controller
{
    public class DataLINQController
    {

        public void GetAll() {
            LINQResult lINQResult = new LINQResult();
            ResultLINQView view = new ResultLINQView();

            var resultDataLINQ = lINQResult.GetAll();
            view.Output(resultDataLINQ);
        }
    }
}
