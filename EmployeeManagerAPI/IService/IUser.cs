using EmployeeManagerAPI.Helpher;
using EmployeeManagerAPI.Service;

namespace EmployeeManagerAPI.IService
{
    public interface IUser
    {
        Task<Response> Register(Model.User user);
        Task<Model.User> Login(Model.UserLogin user);
        Task<Model.User> CurrentUserInfo(string UserName);
    }
}
