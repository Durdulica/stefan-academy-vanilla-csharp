using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Factories;
using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Mappers
{
    public class UserTextMapper : ITextMapper<User>
    {
        private IUserFactory[] factories = new IUserFactory[] { new StudentFactory(), new TeacherFactory(), new AdminFactory() };

        private static string AdminToText(Admin item)
        {
            return "ADMIN," + item.Id + "," + item.FirstName + "," + item.LastName + "," + item.Email
                    + "," + item.Age + "," + item.Salary + "," + item.Password;
        }

        private static string TeacherToText(Teacher item)
        {
            return "TEACHER," + item.Id + "," + item.FirstName + "," + item.LastName + "," + item.Email
                    + "," + item.Age + "," + item.Salary + "," + item.WorkHours + "," + item.Password;
        }

        private static string StudentToText(Student item)
        {
            return "STUDENT," + item.Id + "," + item.FirstName + "," + item.LastName + "," + item.Email + "," + item.Age;
        }


        public string ToText(User item)
        {
            
            if(item is Student s) { return StudentToText(s); }
            if(item is Teacher t) { return TeacherToText(t); }
            if(item is Admin a) { return AdminToText(a); }
            throw new ArgumentException("Unknown user type: " + item.GetType());
        }

        public User FromText(string text) 
        {
            string[] cuv = text.Split(',');

            for (int i = 0; i < factories.Length; i++) 
            {
                if (factories[i].Type == cuv[0])
                {
                    return factories[i].Create(cuv);
                }
            }

            throw new ArgumentException("Unknown user type: " + cuv[0]);
        }
    }
}
