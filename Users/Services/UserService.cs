using stefan_academy_vanilla_charp.Common.Exceptions;
using stefan_academy_vanilla_charp.Users.Dtos;
using stefan_academy_vanilla_charp.Users.Mappers;
using stefan_academy_vanilla_charp.Users.Models;
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

        public User GetUserByFirstAndLastName(string firstName, string lastName)
        {
            return repository.GetByFirstAndLastName(firstName, lastName);
        }

        //CRUD

        public StudentCreateResponse CreateStudent(StudentCreateRequest request)
        {
            if (repository.GetByEmail(request.Email) != null)
            {
                throw new DuplicateException("Studentul", request.Email);
            }

            Student student = UserMapper.ToStudent(request);
            repository.Add(student);
            return UserMapper.StudentToCreateResponse(student);
        }

        public TeacherCreateResponse CreateTeacher(TeacherCreateRequest request) 
        {
            if (repository.GetByEmail(request.Email) != null)
            {
                throw new DuplicateException("Profesorul", request.Email);
            }

            Teacher teacher = UserMapper.ToTeacher(request);
            repository.Add(teacher);
            return UserMapper.TeacherToCreateResponse(teacher);
        }

        public AdminCreateResponse CreateAdmin(AdminCreateRequest request)
        {
            if (repository.GetByEmail(request.Email) != null)
            {
                throw new DuplicateException("Adminul", request.Email);
            }

            Admin admin = UserMapper.ToAdmin(request);
            repository.Add(admin);
            return UserMapper.AdminToCreateResponse(admin);
        }



        public StudentUpdateResponse UpdateStudent(Guid id, StudentUpdateRequest request) 
        {
            Student student = repository.FindById(id) as Student;
            
            if(student == null)
            {
                throw new NotFoundException("Studentul", id.ToString());
            }

            UserMapper.ApplyStudentUpdate(student, request);
            repository.Update(student);
            return UserMapper.ToStudentUpdateResponse(student);
        }

        public TeacherUpdateResponse UpdateTeacher(Guid id, TeacherUpdateRequest request) 
        {
            Teacher teacher = repository.FindById(id) as Teacher;

            if (teacher == null)
            {
                throw new NotFoundException("Profesorul", id.ToString());
            }

            UserMapper.ApplyTeacherUpdate(teacher, request);
            repository.Update(teacher);
            return UserMapper.ToTeacherUpdateResponse(teacher);
        }

        public AdminUpdateResponse UpdateAdmin(Guid id, AdminUpdateRequest request) 
        {
            Admin admin = repository.FindById(id) as Admin;

            if (admin == null)
            {
                throw new NotFoundException("Adminul", id.ToString());
            }

            UserMapper.ApplyAdminUpdate(admin, request);
            repository.Update(admin);
            return UserMapper.ToAdminUpdateResponse(admin);
        }



        public void DeleteUser(Guid id)
        {
            User user = repository.FindById(id);

            if (user == null)
            {
                throw new NotFoundException("Userul", id.ToString());
            }

            repository.Remove(user);
        }
    }
}
