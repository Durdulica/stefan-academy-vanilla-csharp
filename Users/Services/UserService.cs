using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Users.Dtos;
using stefan_academy_vanilla_charp.Users.Mappers;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Models.Students.Dtos;
using stefan_academy_vanilla_charp.Users.Repositories;

namespace stefan_academy_vanilla_charp.Users.Services
{
    public class UserService
    {
        private readonly UserRepository repository;

        public UserService(UserRepository repository) 
        {
            this.repository = repository;
        }

        public User GetUser(Guid id)
        {
            return repository.FindById(id);
        }

        //CRUD

        public StudentCreateResponse CreateStudent(StudentCreateRequest request)
        {
            Student student = UserMapper.ToStudent(request);

            if (repository.FindById(student.Id) != null)
            {
                throw new ArgumentException("Studentul se afla deja in baza de date");
            }

            repository.Add(student);
            return UserMapper.StudentToCreateResponse(student);
        }

        public TeacherCreateResponse CreateTeacher(TeacherCreateRequest request) 
        {
            Teacher teacher = UserMapper.ToTeacher(request);

            if (repository.FindById(teacher.Id) != null)
            {
                throw new ArgumentException("Profesorul se afla deja in baza de date");
            }

            repository.Add(teacher);
            return UserMapper.TeacherToCreateResponse(teacher);
        }

        public AdminCreateResponse CreateAdmin(AdminCreateRequest request)
        {
            Admin admin = UserMapper.ToAdmin(request);

            if (repository.FindById(admin.Id) != null)
            {
                throw new ArgumentException("Adminul se afla deja in baza de date");
            }

            repository.Add(admin);
            return UserMapper.AdminToCreateResponse(admin);
        }



        public StudentUpdateResponse UpdateStudent(Guid id, StudentUpdateRequest request) 
        {
            Student student = repository.FindById(id) as Student;
            
            if(student == null)
            {
                throw new ArgumentException("Studentul nu exista in baza de date");
            }

            UserMapper.ApplyStudentUpdate(student, request);

            return UserMapper.ToStudentUpdateResponse(student);
        }

        public TeacherUpdateResponse UpdateTeacher(Guid id, TeacherUpdateRequest request) 
        {
            Teacher teacher = repository.FindById(id) as Teacher;

            if (teacher == null)
            {
                throw new ArgumentException("Profesorul nu exista in baza de date");
            }

            UserMapper.ApplyTeacherUpdate(teacher, request);

            return UserMapper.ToTeacherUpdateResponse(teacher);
        }

        public AdminUpdateResponse UpdateAdmin(Guid id, AdminUpdateRequest request) 
        {
            Admin admin = repository.FindById(id) as Admin;

            if (admin == null)
            {
                throw new ArgumentException("Adminul nu exista in baza de date");
            }

            UserMapper.ApplyAdminUpdate(admin, request);

            return UserMapper.ToAdminUpdateResponse(admin);
        }

        public void DeleteUser(Guid id)
        {
            User user = repository.FindById(id);
            repository.Remove(user);
        }
    }
}