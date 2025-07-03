using SecureStudentAPI.Filters;
using SecureStudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace SecureStudentAPI.Controllers
{

    /// <summary>
    /// Provides API endpoints for managing student records.    
    /// </summary>
    /// <remarks>The <see cref="StudentController"/> class is responsible for handling HTTP requests related
    /// to student data. It includes operations such as retrieving student details by their unique identifier. This
    /// controller uses basic authentication and operates on a static dataset of predefined student records.</remarks>
    /// 
    /// Explanation
    ///     - the[BasicAuthentication] attribute protects the controller.
    ///     - only users with correct credentials (admin/pass123) can access the data.
    ///
    /// https://www.c-sharpcorner.com/article/basic-auth-in-asp-net-mvc-web-api-using-c-sharp-net/
    /// 
    [BasicAuthentication]
    public class StudentController : ApiController
    {

        /// <summary>
        /// Represents a collection of predefined student records.  
        /// </summary>
        /// <remarks>This static field contains a list of students with their respective details, such as
        /// student ID, name, date of birth, zip code, and major. The list is initialized with sample data and is
        /// intended for use as a static dataset within the application.</remarks>
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                StudentId = "S101",
                Name = "Srinivas P",
                DateOfBirth = new DateTime(2000, 4, 21),
                ZipCode = "600042",
                Major = "Electrical Engineering"
            },
            new Student
            {
                StudentId = "S102",
                Name = "Lavanya Devi",
                DateOfBirth = new DateTime(2001, 10, 5),
                ZipCode = "620001",
                Major = "Civil Engineering"
            }
        };


        /// <summary>
        /// Retrieves a student by their unique identifier. 
        /// </summary>
        /// <param name="id">The unique identifier of the student to retrieve. This value is case-insensitive.</param>
        /// <returns>An <see cref="IHttpActionResult"/> containing the student data if found;  otherwise, a <see
        /// cref="NotFoundResult"/> if no student with the specified identifier exists.</returns>
        public IHttpActionResult Get(string id)
        {
            var student = students.FirstOrDefault(
                s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (student == null)
                return NotFound();

            return Ok(student);
        }
    }
}