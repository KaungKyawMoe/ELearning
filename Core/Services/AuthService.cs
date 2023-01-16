using AutoMapper;
using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Core.Services
{
    public interface IAuthService
    {
        Task<bool> CreateUser(UserDto userDto);

        Task<bool>  UpdateUser(UserDto userDto);

        Task<List<UserDto>> GetAllUsers();


        Task<UserDto> GetUserById(string id);

        Task<RoleDto> GetRoleById(string id);

        Task<List<RoleDto>> GetAllRoles();
    }

    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<e_learningContext> _unitOfWork;

        public AuthService(IMapper mapper,
            IUnitOfWork<e_learningContext> unitOfWork){
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateUser(UserDto userDto)
        {
            User _user = new User();
            _user.Id = Guid.NewGuid().ToString();
            _user.Name= userDto.Name;
            _user.Email= userDto.Email;
            _user.Password= userDto.Password;
            _user.RoleId = userDto.RoleId;
            _user.CreatedOn = DateTime.Now;
            _user.Deleted = 0;

            await _unitOfWork.GetRepository<User>().Create(_user);
            await _unitOfWork.CommitAsync();

            return true;

        }

        public async Task<UserDto> GetUserById(string id)
        {
            var result = await _unitOfWork.GetRepository<User>().GetById(id);
            return _mapper.Map<UserDto>(result);
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var result = await _unitOfWork.GetRepository<User>().GetAll();
            return _mapper.Map<List<UserDto>>(result);
        }


        public async Task<bool> UpdateUser(UserDto userDto)
        {
            var _user = await _unitOfWork.GetRepository<User>().GetById(userDto.Id);
            if(_user != null)
            {
                _user.Email = userDto.Email;
                _user.Password = userDto.Password;
                _user.RoleId = userDto.RoleId;
                _user.UpdatedOn= DateTime.Now;
                _user.Name = userDto.Name;
                _user.Deleted= 0;
            }

            await _unitOfWork.CommitAsync();
            return true;
        }
        public async Task<RoleDto> GetRoleById(string id)
        {
            var role = await _unitOfWork.GetRepository<Role>().GetById(id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<List<RoleDto>> GetAllRoles()
        {
            var roles = await _unitOfWork.GetRepository<Role>().GetAll();
            return _mapper.Map<List<RoleDto>>(roles);
        }

    }
}
