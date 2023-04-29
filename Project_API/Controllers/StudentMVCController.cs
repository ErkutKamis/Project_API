using Project_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Project_API.Controllers
{
    public class StudentMVCController : Controller
    {
        // GET: StudentMVC
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            List<Student> student_list = new List<Student>();
            client.BaseAddress = new Uri("https://localhost:44393/api/Student");
            var response = client.GetAsync("Student");
            response.Wait();

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Student>>();
                display.Wait();
                student_list = display.Result;
            }

            return View(student_list);
        }

        public ActionResult Create() 
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Create(Student std)
        {
            client.BaseAddress = new Uri("https://localhost:44393/api/Student");
            var response = client.PostAsJsonAsync<Student>("Student", std);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            Student s = null;
            client.BaseAddress = new Uri("https://localhost:44393/api/Student");
            var response = client.GetAsync("Student?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(Student s)
        {
            client.BaseAddress = new Uri("https://localhost:44393/api/Student");
            var response = client.PutAsJsonAsync<Student>("Student", s);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            Student s = null;
            client.BaseAddress = new Uri("https://localhost:44393/api/Student");
            var response = client.GetAsync("Student?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }
        [System.Web.Mvc.HttpPost , System.Web.Mvc.ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44393/api/Student");
            var response = client.DeleteAsync("Student/"+id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Delete");
            
        }
    }
}