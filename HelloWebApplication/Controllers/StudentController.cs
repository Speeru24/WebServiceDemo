using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWebApplication.Models;
using HelloWebApplication.StudentWebService;
using AutoMapper;

namespace HelloWebApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int ID)
         {
            StudentModels studentModel = new StudentModels();
            StudentWebService.StudentServiceSoapClient studentService = new StudentWebService.StudentServiceSoapClient();
            var sourceData =  studentService.GetStudentByID(ID);// Gets Data from Web Service
            if(sourceData != null)
            {

                //The following code will cast data from Student type to StudentsModel Type
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<HelloWebApplication.StudentWebService.tblStudent, StudentModels>();
                });

                IMapper mapper = config.CreateMapper();
                var Student = new HelloWebApplication.StudentWebService.tblStudent();
                studentModel = mapper.Map<HelloWebApplication.StudentWebService.tblStudent, StudentModels>(sourceData);
                return Json(new { model = studentModel, flag = true });
            }
            return Json(new { flag = false });
        }


        [HttpPost]
        public ActionResult SaveStudent(StudentModels model)
        {
            StudentWebService.StudentServiceSoapClient client = new StudentServiceSoapClient();
            //tblStudent student = new tblStudent();

            


            



            //The following code will cast data from Student type to StudentsModel Type
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentModels,HelloWebApplication.StudentWebService.tblStudent>();
            });

            IMapper mapper = config.CreateMapper();
            var student = new tblStudent();
            student = mapper.Map<StudentModels, tblStudent>(model);

            bool Flag = client.SaveStudent(student);

            return Json(new { flag = Flag });
        }
    }
}