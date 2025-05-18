using EmployeeManagerAPI.DataContext;
using EmployeeManagerAPI.Helpher;
using EmployeeManagerAPI.IService;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerAPI.Service
{
    public class Employee : IEmployee
    {
        Response response = new Response();

        readonly Context _context;
        public Employee(Context context)
        {
            this._context = context;
        }
        public Task<Response> DeleteEmployee(int id)
        {
            try
            {
                var remove = _context.Employees.Find(id);
                if (remove != null)
                {
                    _context.Employees.Remove(remove);
                    _context.SaveChanges();
                    response.Message = "Record delete successfully!!";
                    response.Status = true;
                    response.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                ErrorHander(ex);
            }
            return Task.FromResult(response);
        }

        public Task<Response> GetEmployee(int id = 0)
        {
            try
            {
                if (id == 0)
                    response.Data = _context.Employees.ToList();
                else
                    response.Data = _context.Employees.Where(x => x.EmployeeId == id).ToList();

                response.Status = true;
                response.Message = "Data retrive successfull!!";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                ErrorHander(ex);
            }
            return Task.FromResult(response);
        }

        public Task<Response> ManageEmployee(Model.Employee employee)
        {
            try
            {
                if (employee.EmployeeId == 0)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    response.Message = "Data inserted successfully !!";
                }
                else
                {
                    _context.Entry(employee).State = EntityState.Modified;
                    _context.SaveChanges();
                    response.Message = "Record updated successfully !!";
                }
                response.Status = true;
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                ErrorHander(ex);
            }
            return Task.FromResult(response);
        }

        void ErrorHander(Exception ex)
        {
            response.Data = null;
            response.Status = false;
            response.Message = "Technical Error!!";
            response.StatusCode = 500;
            //for log ex.Message
        }

    }
}
