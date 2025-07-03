using System;

namespace SecureStudentAPI.Models
{

    ///
    /// https://www.c-sharpcorner.com/article/basic-auth-in-asp-net-mvc-web-api-using-c-sharp-net/
    /// 
    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ZipCode { get; set; }
        public string Major { get; set; }
    }
}