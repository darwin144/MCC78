using CRUD_Tugas_MCC.View;


namespace CRUD_Tugas_MCC.Controller
{
    public class MenuController
    {       
        public void PilihMenuUtama() {
            MenuView view = new MenuView();
            DataLINQController linqController = new DataLINQController();
            EmployeeController employeeController = new EmployeeController();
            EducationController educationController = new EducationController();
            UniversityController university = new UniversityController();


            Console.Write("masukkan Pilihan :");
            int menuUtama = Convert.ToInt32(Console.ReadLine());
            switch (menuUtama)
            {
                case 1:
                    view.MenuUniversity();
                    view.MenuUtama();
                    break;
                case 2:
                    view.MenuEducation();
                    view.MenuUtama();
                    break;
                case 3:
                    MenuInsertToManyTable();
                    view.MenuUtama();
                    break;
                case 4:
                    employeeController.GetAll();
                    view.MenuUtama();
                    break;
                case 5:
                    linqController.GetAll();
                    view.MenuUtama();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    view.MenuUtama();
                    break;
            }
        }      
        public void MenuInsertToManyTable() {
            MenuView view = new MenuView();
            view.InsertManyTable();
        }
       
        
    }
}
