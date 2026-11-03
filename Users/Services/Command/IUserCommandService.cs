using stefan_academy_vanilla_charp.Users.Dtos;

namespace stefan_academy_vanilla_charp.Users.Services.Command
{
    public interface IUserCommandService
    {
        StudentCreateResponse CreateStudent(StudentCreateRequest request);

        TeacherCreateResponse CreateTeacher(TeacherCreateRequest request);

        AdminCreateResponse CreateAdmin(AdminCreateRequest request);




        StudentUpdateResponse UpdateStudent(Guid id, StudentUpdateRequest request);

        TeacherUpdateResponse UpdateTeacher(Guid id, TeacherUpdateRequest request);

        AdminUpdateResponse UpdateAdmin(Guid id, AdminUpdateRequest request);




        void DeleteUser(Guid id);
    }
}
