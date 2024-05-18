using Domain.Models;

namespace Application.Interfaces.RoleServiceInterfaces
{
    public interface IRoleService
    {
        Task<List<Role>> ReadRoles();

        Task<Role> ReadRoleById(int roleId);
    }
}