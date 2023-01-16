using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controllers
{

    public interface IAuthController
    {
        public List<UserDto> GetAllUsers();

        public UserDto GetUserById(string id);

        public bool CreateUser(UserDto user);

        public bool UpdateUser(UserDto user);

        public List<RoleDto> GetRoles();

        public RoleDto GetRoleById(string id);
    }
    public class AuthController : IAuthController
    {
        public bool CreateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public RoleDto GetRoleById(string id)
        {
            throw new NotImplementedException();
        }

        public List<RoleDto> GetRoles()
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
