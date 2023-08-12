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
 
            String query = "select * from courses as c " +
                           "join instructors as I on c.Instructor_id=I.Id " +
                           "join enrollments as e on c.Id = e.CourseId where c.id = @id";
            
            
            
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
        string connectionString = "Server=localhost;Database=master;User Id=sa;Password=admin123*";
        SqlConnection con = new SqlConnection(connectionString);
        using (con)
        {
            con.Open();
            string query = "INSERT INTO Enrollments (Id, StudentId, CourseId) VALUES (@Id, @StudentId, @CourseId)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Id",_enrollStudentViewModel.Id);
                command.Parameters.AddWithValue("@StudentId",_enrollStudentViewModel.studentId);
                command.Parameters.AddWithValue("@CourseId",_enrollStudentViewModel.courseId);
                
                int rowsAffected = command.ExecuteNonQuery();

                return new JsonResult(_enrollStudentViewModel);
            }
        }
        
    }

    [Route("UpdateCourse")]
    [HttpPut]
    public JsonResult UpdateCourse(UpdateCourseViewModel _updateCourseViewModel)
    {
        string connectionString = "Server=localhost;Database=master;User Id=sa;Password=admin123*";
        SqlConnection con = new SqlConnection(connectionString);
        using (con)
        {
            con.Open();
            string query = "UPDATE Courses SET courseName = @courseName, InstructorId = @InstructorId WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@courseName",_updateCourseViewModel.courseName);
                command.Parameters.AddWithValue("@InstructorId",_updateCourseViewModel.InstructorId);
                command.Parameters.AddWithValue("@Id",_updateCourseViewModel.Id);
                
                int rowsAffected = command.ExecuteNonQuery();

                return new JsonResult(_updateCourseViewModel);
            }
        }
    }

    [Route("DeleteCourse")]
    [HttpDelete]
    public JsonResult DeleteCourse(DeleteCourseViewModel _deleteCourseViewModel)
    {
        
    }
    
    
    
    
    
    
    
    

}
