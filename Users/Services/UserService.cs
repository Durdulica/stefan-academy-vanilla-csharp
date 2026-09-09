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

        //CRUD

        public User GetUser(Guid id)
        {
            return repository.FindById(id);
        }


        public UserCreateResponse CreateUser(UserCreateRequest request) {
            User newUser;

            TeacherCreateRequest t = request as TeacherCreateRequest;
            AdminCreateRequest a = request as AdminCreateRequest;

            if (request != null)
            {
                Student newS = new();
                newS.FirstName = request.FirstName;
                newS.LastName = request.LastName;
                newS.Email = request.Email;
                newS.Age = request.Age;
                newUser = newS;
            }
            else if (t != null)
            {
                Teacher newT = new();
                newT.FirstName = t.FirstName;
                newT.LastName = t.LastName;
                newT.Email = t.Email;
                newT.Age = t.Age;
                newT.Salary = t.Salary;
                newT.WorkHours = t.WorkHours;
                newT.Password = t.Password;
                newUser = newT;
            }
            else if (a != null)
            {
                Admin newA = new();
                newA.FirstName = a.FirstName;
                newA.LastName = a.LastName;
                newA.Email = a.Email;
                newA.Age = a.Age;
                newA.Salary = a.Salary;
                newA.Password = a.Password;
                newUser = newA;
            }
            else
            {
                throw new ArgumentException("Create requestul nu este de niciun tip");
            }

            repository.Add(newUser);
            return UserMapper.ToCreateResponse(newUser);
        }

        /*public UserUpdateResponse UpdateUser(Guid id, UserUpdateRequest request)
        {
            User u = FindById(id);

            if (u == null) {
                throw new ArgumentException("Userul pe care incercati sa il modificati nu se afla in baza de date");
            }

            u.Update(request);

            return UserToUserUpdateResponse(u);
        }

        public void DeleteUser(Guid id)
        {
            User user = FindById(id);
            users.Remove(user);
        }

        public string UserListToString()
        {
            string list = "";
            for (int i = 0; i < users.Count; i++) {
                list += users[i].ToText(i,users.Count);
            }

            return list;
        }

        public void Save()
        {
            string path = Path.Combine("..", "..", "..", "Data", "users.txt");

            using var writer = new StreamWriter(path);
            string list = UserListToString();
            writer.Write(list);
        }*/
    }
}
