﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagerAPI.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }        
        public string? Username { get; set; }     
        public string? Email { get; set; }          
        public string? Password { get; set; }       
        public string? FullName { get; set; }      
        public DateTime Created { get; set; }
        public string? Role { get; set; }
    }
    public class UserLogin
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
   
}
