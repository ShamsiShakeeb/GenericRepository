//https://stackoverflow.com/questions/1567084/how-can-i-inherit-an-asp-net-mvc-controller-and-change-only-the-view


using GenericMvc.Models;
using GenericMvc.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericMvc.Controllers
{
    public class BaseController<T> : Controller where T : BaseEntity
    {
        public Repository<T> _repoStudent;
        
        public BaseController()
        {
            _repoStudent = new Repository<T>();
        }
        [HttpGet]
        public virtual IActionResult Index()
        {
            var result = _repoStudent.GetAll();
            return Ok(new { message = result.message, data = result.data, success = result.success, error = result.error });
        }
        [HttpPost]
        public virtual IActionResult Insert(T a)
        {
            var result = _repoStudent.Insert(a);
            return Ok(new { message = result.message, data=result.data, success = result.success, error = result.error });
        }
        [HttpPost]
        public virtual IActionResult Update(T a)
        {
            Func<T, bool> expression = x => x.Id == a.Id;
            var result = _repoStudent.Update(expression, a);
            return Ok(new { message = result.message, data = result.data, success = result.success, error = result.error });
        }
        [HttpPost]
        public virtual IActionResult Delete(T a)
        {
            Func<T, bool> expression = x => x.Id == a.Id;
            var result = _repoStudent.Delete(expression);
            return Ok(new { message = result.message, data = result.data, success = result.success, error = result.error });
        }
        [HttpGet]
        public virtual IActionResult Search(int id)
        {
            Func<T, bool> expression = x => x.Id == id;
            var result = _repoStudent.Search(expression);
            return Ok(new { message = result.message, data = result.data, success = result.success, error = result.error });
        }
    }
}
