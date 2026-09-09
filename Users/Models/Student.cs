using stefan_academy_vanilla_charp.Users.Dtos;

namespace stefan_academy_vanilla_charp.Users.Models
{
    public class Student : User
    {
        public Student(Guid id, string firstName, string lastName, string email, int age) 
            : base(id, firstName, lastName, email, age) { }

        public Student(string firstName, string lastName, string email, int age) 
            : base(firstName, lastName, email, age) { }


        /*public override string ToText(int cnt, int size)
        {
            string list = "";
            if (cnt + 1 == size)
            {
                list += "STUDENT," + Id + "," + FirstName + "," + LastName + "," + Email + "," + Age;
            }
            else
            {
                list += "STUDENT," + Id + "," + FirstName + "," + LastName + "," + Email + "," + Age + "\n";
            }
            return list;
        }

        public override void Create(UserCreateRequest request)
        {
            base.Create(request);
        }

        public override void Update(UserUpdateRequest request)
        {
            base.Update(request);
        }*/
    }
}
