using Core.Entities;
using Core.Models;
using Core.Models.Index;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Core.Services
{
    public interface IPermissionService
    {
        public Task<List<PermissionIndex>> GetList();

        public Task<ResultModel<Object>> UpdatePermission(List<PermissionDto> data);

        public Task<ResultModel<MenuPermission>> GetMenuPermissionByMenuName(string menuName);
    }

    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork<Context> unitOfWork;
        public PermissionService(IUnitOfWork<Context> _unitOfWork)
        {
            unitOfWork = _unitOfWork; 
        }
        public async Task<List<PermissionIndex>> GetList()
        {
            try
            {
                Dictionary<string,object> parameters = new Dictionary<string,object>();
                string select = $"select p.id,m.name as menuName,m.id as menuId,r.id as roleId,r.name as roleName,p.action";
                string from = " from menu m";
                string join = " cross join roles r left join menu_permission p on p.menu_id = m.id and r.id = p.role_id";
                string where = " order by p.id";
                parameters.Add("_select",select);
                parameters.Add("_table",from);
                parameters.Add("_joinTable",join);
                parameters.Add("_where",where);
                parameters.Add("_skip",0);
                parameters.Add("_take",30);
                var result = await unitOfWork.GetRepository<PermissionIndex>().ExecuteStoredProcedure("GetList",parameters);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<ResultModel<object>> UpdatePermission(List<PermissionDto> data)
        {
            ResultModel<Object> result = new ResultModel<object>();
            try
            {
                foreach(var item in data)
                {
                    var permission = await unitOfWork.GetRepository<MenuPermission>().GetById(item.Id);

                    permission.Action = item.Action;

                    await unitOfWork.CommitAsync();
                }

                result = new ResultModel<object>()
                {
                    IsSuccess = true
                };
            }
            catch(Exception ex)
            {
                result = new ResultModel<object>()
                {
                    IsSuccess = false
                };
            }
            return result;
        }

        public async Task<ResultModel<MenuPermission>> GetMenuPermissionByMenuName(string menuName)
        {
            ResultModel<MenuPermission> result = new ResultModel<MenuPermission>();
            try
            {
                var menu = await unitOfWork.GetRepository<MenuPermission>().Find(x => x.Menu.Name == menuName);

                if (menu.Any())
                {
                    result.IsSuccess = true;
                    result.Data = menu.FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
