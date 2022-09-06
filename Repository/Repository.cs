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
        public (bool success , string message , T data , string error) Insert(T a)
        {
            try
            {
                list.Add(a);
                return (success: true,
                    message: "Data Inserted Successfully",
                    data: a,
                    error: null);
            }
            catch(Exception ex)
            {
                return (success: false,
                    message: "Data not Inserted Successfully",
                    data: a,
                    error: ex.Message.ToString());
            }
        }
        public (bool success, string message, T data, string error) Update(Func<T, bool> expression , T a)
        {
            try
            {
                Delete(expression);
                Insert(a);
                return (success: true,
                       message: "Data Updated Successfully",
                       data: a,
                       error: null);
            }
            catch(Exception ex)
            {
                return (success: false,
                       message: "Data not Updated Successfully",
                       data: a,
                       error: ex.Message.ToString());
            }
        }
        public (bool success, string message, T data, string error) Delete(Func<T, bool> expression)
        {
            try
            {
                var data = list.Where(expression).FirstOrDefault();
                list.Remove(data);
                return (success: true,
                          message: "Data Deleted Successfully",
                          data: data,
                          error: null);
            }
            catch(Exception ex)
            {
                return (success: false,
                          message: "Data not Deleted Successfully",
                          data: null,
                          error: ex.Message.ToString());
            }
        }
        public (bool success, string message, T data, string error) Search(Func<T, bool> expression)
        {
            try
            {
                var data = list.Where(expression).FirstOrDefault();
                return (success: true,
                              message: data!=null ? "Data Found" : "Data Not Found",
                              data: data,
                              error: null);
            }
            catch(Exception ex)
            {
                return (success: false,
                              message: "Something Went Wrong",
                              data: null,
                              error: ex.Message.ToString());
            }
        }
        public (bool success, string message, List<T> data, string error) GetAll(Func<T, bool> expression = null)
        {
            var data = expression == null ? list : list.Where(expression).ToList();
            return (success: true,
                    message: list.Any() ? "Data Found" : "Data Not Found",
                    data: data,
                    error: null);
        }

       
    }
}
