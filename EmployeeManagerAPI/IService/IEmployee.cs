using EmployeeManagerAPI.Helpher;

namespace EmployeeManagerAPI.IService
{
    public interface IEmployee
    {
        Task<Response> GetEmployee(int id = 0);
        Task<Response> ManageEmployee(EmployeeManagerAPI.Model.Employee employee);
        Task<Response> DeleteEmployee(int id);
    }
}
