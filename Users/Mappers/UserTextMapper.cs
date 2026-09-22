using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Mappers
{
    public class UserTextMapper : ITextMapper<User>
    {
        public static string AdminToText(Admin item)
        {
            return "ADMIN," + item.Id + "," + item.FirstName + "," + item.LastName + "," + item.Email
                    + "," + item.Age + "," + item.Salary + "," + item.Password;
        }

        public static Admin AdminFromText(string text)
        {
            string[] cuv = text.Split(',');

            return new Admin(Guid.Parse(cuv[1]), cuv[2], cuv[3], cuv[4], Int32.Parse(cuv[5]), Int32.Parse(cuv[6]), cuv[7]);
        }

        public static string TeacherToText(Teacher item)
        {
            return "TEACHER," + item.Id + "," + item.FirstName + "," + item.LastName + "," + item.Email
                    + "," + item.Age + "," + item.Salary + "," + item.WorkHours + "," + item.Password;
        }

        public static Teacher TeacherFromText(string text)
        {
            string[] cuv = text.Split(',');

            return new Teacher(Guid.Parse(cuv[1]), cuv[2], cuv[3], cuv[4], int.Parse(cuv[5]),
                int.Parse(cuv[6]), int.Parse(cuv[7]), cuv[8]);
        }

        public static string StudentToText(Student item)
        {
            return "STUDENT," + item.Id + "," + item.FirstName + "," + item.LastName + "," + item.Email + "," + item.Age;
        }

        public static Student StudentFromText(string text)
        {
            string[] cuv = text.Split(',');

            return new Student(Guid.Parse(cuv[1]), cuv[2], cuv[3], cuv[4], Int32.Parse(cuv[5]));
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

            switch (cuv[0])
            {
                case "STUDENT": return StudentFromText(text);
                case "TEACHER": return TeacherFromText(text);
                case "ADMIN": return AdminFromText(text);
                default: throw new ArgumentException("Unknown user type: " + cuv[0]);
            }
        }
    }
}