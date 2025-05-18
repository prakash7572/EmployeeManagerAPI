using EmployeeManagerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerAPI.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> o) : base(o) { }

        public DbSet<Model.Employee>  Employees { get; set; }
        public DbSet<Model.User> Users { get; set; }

    }
}
