using stefan_academy_vanilla_charp.Admins.Dtos;
using stefan_academy_vanilla_charp.Admins.Models;

namespace stefan_academy_vanilla_charp.Admins.Services
{
    public class AdminService
    {
        List<Admin> admins = new List<Admin>();

        //Finders

        public Admin FindById(Guid Id)
        {
            foreach (Admin adm in admins)
            {
                if (adm.Id == Id) return adm;
            }
            return null;
        }

        //Mappers

        public Admin AdminCreateRequestToAdmin(AdminCreateRequest request)
        {
            return null;
        }

        public AdminCreateResponse AdminToAdminCreateResponse(Admin admin)
        {
            return null;
        }

        public Admin AdminUpdateRequestToAdmin(AdminUpdateRequest request)
        {
            return null;
        }

        public AdminUpdateResponse AdminToAdminUpdateResponse(Admin admin)
        {
            return null;
        }

        //CRUD
    }
}
