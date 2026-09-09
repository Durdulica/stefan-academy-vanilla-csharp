using stefan_academy_vanilla_charp.Users.Dtos;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Models.Students.Dtos;

namespace stefan_academy_vanilla_charp.Users.Mappers
{
    public class UserMapper
    {
        //STUDENT

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

        public static StudentUpdateResponse ToStudentUpdateResponse(User user) 
        {
            return new StudentUpdateResponse(user.Id, user.FirstName, user.LastName, user.Email);
        }

        //TEACHER

        public static Teacher ToTeacher(TeacherCreateRequest request)
        {
            return new Teacher(request.FirstName, request.LastName, request.Email,
                request.Age, request.Salary, request.WorkHours, request.Password);
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

        public static TeacherCreateResponse TeacherToCreateResponse(Teacher user)
        {
            return new TeacherCreateResponse(user.Id, user.FirstName, user.LastName, user.Email, 
                user.Age, user.Salary, user.WorkHours, user.Password);
        }

        public static TeacherUpdateResponse ToTeacherUpdateResponse(Teacher user)
        {
            return new TeacherUpdateResponse(user.Id, user.FirstName, user.LastName, user.Email,
                user.Salary, user.WorkHours, user.Password);
        }

        //ADMIN

        public static Admin ToAdmin(AdminCreateRequest request)
        {
            return new Admin(request.FirstName, request.LastName, request.Email,
                request.Age, request.Salary, request.Password);
        }

        public static void ApplyAdminUpdate(Admin user, AdminUpdateRequest request)
        {
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Salary = request.Salary;
            user.Password = request.Password;
        }

        public static AdminCreateResponse AdminToCreateResponse(Admin user)
        {
            return new AdminCreateResponse(user.Id, user.FirstName, user.LastName, user.Email,
                user.Age, user.Salary, user.Password);
        }

        public static AdminUpdateResponse ToAdminUpdateResponse(Admin user)
        {
            return new AdminUpdateResponse(user.Id, user.FirstName, user.LastName, user.Email,
                user.Salary, user.Password);
        }
    }
}