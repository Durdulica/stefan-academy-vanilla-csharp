using stefan_academy_vanilla_charp.Users.Dtos;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Models.Students.Dtos;

namespace stefan_academy_vanilla_charp.Users.Mappers
{
    public class UserMapper
    {
        public static Student ToStudent(StudentCreateRequest request)
        {
            return new Student(request.FirstName, request.LastName, request.Email, request.Age);
        }

        public static void ApplyStudentUpdate(Student user, StudentUpdateRequest request)
        {
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
        }

        public static StudentCreateResponse StudentToCreateResponse(Student user)
        {
            return new StudentCreateResponse(user.Id, user.FirstName, user.LastName, user.Email, user.Age);
        }

        public static StudentUpdateResponse ToUpdateResponse(User user) 
        {
            return new StudentUpdateResponse(user.Id, user.FirstName, user.LastName, user.Email);
        }

        public static User ToTeacher(TeacherCreateRequest request)
        {
            return new Teacher(request.FirstName, request.LastName, request.Email,
                request.Age, request.Salary, request.Password, request.WorkHours);
        }

        public static void ApplyTeacherUpdate(Teacher user, TeacherUpdateRequest request)
        {
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Salary = request.Salary;
            user.Password = request.Password;
            user.WorkHours = request.WorkHours;
        }

        public static StudentCreateResponse StudentToCreateResponse(Student user)
        {
            return new StudentCreateResponse(user.Id, user.FirstName, user.LastName, user.Email, user.Age);
        }

        public static StudentUpdateResponse ToUpdateResponse(User user)
        {
            return new StudentUpdateResponse(user.Id, user.FirstName, user.LastName, user.Email);
        }
    }
}
