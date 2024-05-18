using Application.Interfaces.RoleServiceInterfaces;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services.RoleServices;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<List<Role>> ReadRoles()
    {
        return await _roleRepository.ReadRolesAsync();
    }

    public async Task<Role> ReadRoleById(int roleId)
    {
        return await _roleRepository.ReadRoleByIdAsync(roleId);
    }
}
