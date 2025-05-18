using EmployeeManagerAPI.DataContext;
using EmployeeManagerAPI.Helpher;
using EmployeeManagerAPI.IService;
using EmployeeManagerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerAPI.Service
{
    public class User : IUser
    {
        Response response = new Response();
        readonly Context _context;
        public User(Context context)
        {
            this._context = context;
        }
       
        public Task<Model.User> Login(Model.UserLogin user)
        {
            Model.User use = new Model.User();
            try
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);

                if (existingUser != null)
                    use.Username = existingUser?.Username;
                    use.Password = existingUser?.Password;
                    use.Role = existingUser?.Role;

            }
            catch (Exception ex)
            {
                ErrorHander(ex);
            }
            return Task.FromResult(use);
        }

        public Task<Response> Register(Model.User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                response.Data = user;
                response.Message = "User created successfully !!";
                response.Status = true;
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                ErrorHander(ex);
            }
            return Task.FromResult(response);
        }
        
        public async Task<Model.User?> CurrentUserInfo(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    return null;

                return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            }
            catch (Exception)
            {
                return null;
            }
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
