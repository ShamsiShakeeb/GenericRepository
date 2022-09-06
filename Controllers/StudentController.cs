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
        [Route("api/student/index")]
        [HttpGet]
        public IActionResult Index()
        {
            var data = _repoStudent.GetAll();
            return Ok(new { data = data});
        }
        [Route("api/student/insert")]
        [HttpPost]
        public IActionResult Insert(Student student)
        {
            _repoStudent.Insert(student);
            return Ok(new { data = _repoStudent.GetAll() });
        }
        [Route("api/student/update")]
        [HttpPost]
        public IActionResult Update(Student student)
        {
            _repoStudent.Update(x => x.Id == student.Id, student);
            return Ok(new { data = _repoStudent.GetAll()});
        }
        [Route("api/student/delete")]
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _repoStudent.Delete(x => x.Id == student.Id);
            return Ok(new { data = _repoStudent.GetAll() });
        }
        [Route("api/student/search/{searchValue}")]
        [HttpGet]
        public IActionResult Search(string searchValue)
        {
            var data = _repoStudent.Search(x => x.Id.ToString().Contains(searchValue)
            || x.Email.Contains(searchValue)
            || x.Phone.Contains(searchValue)
            || x.Name.Contains(searchValue)
            || x.Address.Contains(searchValue)
            || x.Cgpa.ToString().Contains(searchValue));
            return Ok(new {data = data});
        }
    }
}
