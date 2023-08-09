using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace CourseWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    [Route("GetAllCourses")]
    [HttpGet]
    public JsonResult GetAllCourses()
    {
        string connectionString = "Server=localhost;Database=master;User Id=sa;Password=admin123*";
        SqlConnection con = new SqlConnection(connectionString);
        using (con)
        {
            con.Open();
            String query = "SELECT * From Courses";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                List<ResultCourses> courses = new List<ResultCourses>();
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new ()
                        {
                            Id = (int)reader["Id"],
                            courseName = reader["courseName"].ToString(),
                            instructorId = (int)reader["InstructorId"]
                        });
                    }
                }
                return new JsonResult(courses);
            }
        }
    }

    [Route("GetSpecific")]
    [HttpGet]
    public JsonResult GetSpecific(GetSpecificViewModel _getSpecificViewModel)
    {
        string connectionString = "Server=localhost;Database=master;User Id=sa;Password=admin123*";
        SqlConnection con = new SqlConnection(connectionString);
        using (con)
        {
            con.Open();
 
            
        }
    }

    [Route("CreateCourse")]
    [HttpPost]
    public JsonResult InsertCourse(CourseViewModel _courseViewModel, InsertInstructorViewModel _insertInstructorViewModel)
    {
        
    }

    [Route("ٍEnrollStudent")]
    [HttpPost]
    public JsonResult EnrollStudent(EnrollStudentViewModel _enrollStudentViewModel)
    {
        
    }

    [Route("UpdateCourse")]
    [HttpPut]
    public JsonResult UpdateCourse(UpdateCourseViewModel _updateCourseViewModel)
    {
        
    }

    [Route("DeleteCourse")]
    [HttpDelete]
    public JsonResult DeleteCourse(DeleteCourseViewModel _deleteCourseViewModel)
    {
        
    }
    
    
    
    
    
    
    
    

}
