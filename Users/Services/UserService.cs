using stefan_academy_vanilla_charp.Users.Dtos;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Models.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Services
{
    public class UserService
    {
        List<User> users = new();

        public UserService() {
            ReadUsers();
        }

        //Finders

        public User FindById(Guid id) {
            foreach (var user in users) {
                if(id.CompareTo(user.Id) == 0)
                {
                    return user;
                }
            }
            return null;
        }

        public User GetByFirstAndLastName(string firstName, string lastName)
        {
            foreach (var user in users)
            {
                if(user.FirstName.CompareTo(firstName) == 0 && user.LastName.CompareTo(lastName) == 0)
                {
                    return user;
                }
            }

            return null;
        }

        //Mappers

        public User UserCreateRequestToUser(UserCreateRequest request)
        {
            return new User(request.FirstName, request.LastName, request.Email, request.Age);
        }

        public UserCreateResponse UserToUserCreateResponse(User user)
        {
            return new UserCreateResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age
            };
        }

        public UserUpdateResponse UserToUserUpdateResponse(User user)
        {
            return new UserUpdateResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age
            };
        }

        //CRUD

        public List<User> GetUsers {
            get { return users; }
        }

        public UserCreateResponse CreateUser(UserCreateRequest request) {
            User newUser = new();

            newUser.Create(request);

            users.Add(newUser);
            return UserToUserCreateResponse(newUser);
        }

        private void ReadUsers()
        {
            string path = Path.Combine("..", "..", "..", "Data", "users.txt");

            using (var reader = new StreamReader(path)) {

                string line = "";
                while ((line = reader.ReadLine()) != null) {
                    string[] cuv = line.Split(',');
                    switch (cuv[0])
                    {
                        case "STUDENT": users.Add(new Student(line)); break;
                        case "TEACHER": users.Add(new Teacher(line)); break;
                        case "ADMIN": users.Add(new Admin(line)); break;
                        default: throw new ArgumentException("Eroare in fisierul de citire!!!");
                    }
                }
            }
        }

        public UserUpdateResponse UpdateUser(Guid id, UserUpdateRequest request)
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

            using (var writer = new StreamWriter(path)) {
                string list = UserListToString();
                writer.Write(list);
            }
        }
    }
}
