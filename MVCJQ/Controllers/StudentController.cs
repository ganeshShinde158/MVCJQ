using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCJQ.Models;

namespace MVCJQ.Controllers
{
    public class StudentController : Controller
    {
        PractiseDBEntities db;
        public StudentController()
        {
            db = new PractiseDBEntities();
        }
        // GET: Student
        public ActionResult Index()
        {
           
            return View();
        }
        public JsonResult GetAllStudents()
        {
            List<Student> st = db.Students.ToList();
            return Json(st,JsonRequestBehavior.AllowGet);    
        }
        [HttpPost]
        public string AddStudent(Student st)
        {
            db.Students.Add(st);
            db.SaveChanges();
            return "Students Added Successfully";

        }
        [HttpPost]

        public string Updatestudent(Student st)
        {
            db.Entry<Student>(st).State= System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Student Updated Successfully";

        }
        public JsonResult GetStudent(int id)
        {
            Student st = db.Students.Find(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        public string DeleteStudent(int id )
        {
            Student st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            return "Student Deleted Successfully";

        }
    }
}