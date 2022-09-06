using GenericMvc.Models;
using GenericMvc.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericMvc.Controllers
{
    public class StudentController : Controller
    {
        public Repository<Student> _repoStudent;
        public StudentController()
        {
            _repoStudent = new Repository<Student>();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _repoStudent.GetAll();
            return View(data);
        } 
        [HttpPost]
        public IActionResult Insert(Student student)
        {
            _repoStudent.Insert(student);
            return Redirect("~/Student/Index");
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            _repoStudent.Update(x => x.Id == student.Id, student);
            return Redirect("~/Student/Index");
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _repoStudent.Delete(x => x.Id == student.Id);
            return Redirect("~/Student/Index");
        }
        [HttpGet]
        public IActionResult Search(string searchValue)
        {
            var data = _repoStudent.Search(x => x.Id.ToString().Contains(searchValue)
            || x.Email.Contains(searchValue)
            || x.Phone.Contains(searchValue)
            || x.Name.Contains(searchValue)
            || x.Address.Contains(searchValue)
            || x.Cgpa.ToString().Contains(searchValue));
            return View("index",data);
        }
    }
}
