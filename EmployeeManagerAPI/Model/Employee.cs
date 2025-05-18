using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagerAPI.Model
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; } 
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? Email { get; set; }  
        public string? PhoneNumber { get; set; }  
        public DateTime HireDate { get; set; }  
        public string? JobTitle { get; set; }  
        public string? Department { get; set; }
        public decimal? Salary { get; set; }  
    }
}
