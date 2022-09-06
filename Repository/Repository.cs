using GenericMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericMvc.Repository
{
    public class Repository<T> where T : class
    {
        public static List<T> list = new List<T>();
        public void Insert(T a)
        {
            list.Add(a);
        }
        public void Update(Func<T, bool> expression , T a)
        {
            Delete(expression);
            Insert(a);
        }
        public void Delete(Func<T, bool> expression)
        {
            var data = list.Where(expression).FirstOrDefault();
            list.Remove(data);
        }
        public List<T> Search(Func<T, bool> expression)
        {
            var data = list.Where(expression).ToList();
            return data;
        }
        public List<T> GetAll()
        {
            //(return select * from list);
            return list;
        }

       
    }
}
