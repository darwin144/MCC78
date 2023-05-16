using CRUD_Tugas_MCC.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Tugas_MCC.Model
{
    public class LINQResult
    {
        public string NIK { get; set; }
        public string Fullname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public string UniversityName { get; set; }
        public LINQResult() { }
        public LINQResult(string nIK, string fullname, DateTime birthdate, string gender, DateTime hiringDate, string email, string phoneNumber, string major, string degree, string gPA, string universityName)
        {
            NIK = nIK;
            Fullname = fullname;
            Birthdate = birthdate;
            Gender = gender;
            HiringDate = hiringDate;
            Email = email;
            PhoneNumber = phoneNumber;
            Major = major;
            Degree = degree;
            GPA = gPA;
            UniversityName = universityName;
        }

        public List<LINQResult> GetAll()
        {
           
            List<LINQResult> resultLINQ = new List<LINQResult>();
            ICRUD<List<Employee>, Employee> employees = new Employee();
            var profilling = new Profilling();
            var education = new Education();
            var university = new University();

            var getEmployee = employees.GetAll().Join(profilling.GetAll(), employeex => employeex.Id,
                    profillingx => profillingx.EmployeeId, (employeex, profillingx) => new { employeex, profillingx }
                 ).Join(education.GetAll(), profillingy => profillingy.profillingx.EducationId,
                    educationx => educationx.Id, (profillingy, educationx) => new
                    {
                        profillingy.employeex,
                        profillingy.profillingx,
                        educationx
                    }
                 ).Join(university.GetAll(), finalJoin => finalJoin.educationx.IdUniversity,
                        universitas => universitas.IdUniversity, (finalJoin, universitas) => new
                        {
                            finalJoin.employeex,
                            finalJoin.profillingx,
                            finalJoin.educationx,
                            universitas
                        }
                 ).Select(finalJoin => new
                 {
                     finalJoin.employeex.NIK,
                     FullName = string.Concat(finalJoin.employeex.FirstName, " ", finalJoin.employeex.LastName),
                     finalJoin.employeex.Birthdate,
                     finalJoin.employeex.Gender,
                     finalJoin.employeex.HiringDate,
                     finalJoin.employeex.Email,
                     finalJoin.employeex.PhoneNumber,
                     finalJoin.educationx.Major,
                     finalJoin.educationx.Degree,
                     finalJoin.educationx.GPA,
                     UniversityName = finalJoin.universitas.Name
                 }).ToList();

            foreach (var data in getEmployee)
            {
                LINQResult objectLINQ = new LINQResult();
                objectLINQ.NIK = data.NIK;
                objectLINQ.Fullname = data.FullName;
                objectLINQ.Birthdate = data.Birthdate;
                objectLINQ.Gender = data.Gender;
                objectLINQ.HiringDate = data.HiringDate;
                objectLINQ.Email = data.Email;
                objectLINQ.PhoneNumber = data.PhoneNumber;
                objectLINQ.Major = data.Major;
                objectLINQ.Degree = data.Degree;
                objectLINQ.GPA = data.GPA;
                objectLINQ.UniversityName = data.UniversityName;

                resultLINQ.Add(objectLINQ);
            }
            return resultLINQ;
        }
    }
}