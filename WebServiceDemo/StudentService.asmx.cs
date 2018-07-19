using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceDemo
{
    /// <summary>
    /// Summary description for StudentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class StudentService : System.Web.Services.WebService
    {

        Practise_JeffEntities db = new Practise_JeffEntities();
        [WebMethod]
        public tblStudent GetStudentByID(int ID)
        {
            tblStudent student = new tblStudent();
            var studentData = db.tblStudents.FirstOrDefault(s => s.ID == ID);
            if (studentData != null)
            {
                student.ID = ID;
                student.Name = studentData.Name;
                student.Gender = studentData.Gender;
                student.TotalMarks = studentData.TotalMarks ?? 0;
                return student;
            }
            return null;
            
        }
        [WebMethod]
        public bool SaveStudent(tblStudent student)
        {
            var studentData = db.tblStudents.FirstOrDefault(s => s.ID == student.ID);
            if(studentData != null)
            {
                db.Entry(studentData).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                db.tblStudents.Add(student);

            }
            return false;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
