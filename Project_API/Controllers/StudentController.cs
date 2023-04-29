using Project_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Project_API.Controllers
{
    public class StudentController : ApiController
    {
        StudentDBEntities db = new StudentDBEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudent()
        {
            List<Student> list = db.Students.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudentById(int id)
        {
            var std = db.Students.Where(model => model.StudentID == id).FirstOrDefault();
            return Ok(std);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult StudentInsert(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult StudentUpdate(Student s)
        {
            var std = db.Students.Where(model => model.StudentID == s.StudentID).FirstOrDefault();
            if (std != null)
            {
                std.StudentID = s.StudentID;
                std.Name = s.Name;
                std.SurName = s.SurName;
                std.Note = s.Note;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult StudentDelete(int id)
        {
            var std = db.Students.Where(model => model.StudentID == id).FirstOrDefault();
            db.Entry(std).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

    }
}
