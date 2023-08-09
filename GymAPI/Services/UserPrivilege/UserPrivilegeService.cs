using System.Data.Entity;
using GymAPI.Data;

namespace GymAPI.Services.UserPrivilege;

public class UserPrivilegeService : IUserPrivilegeService
{
    private readonly DataContext dataContext;

    public UserPrivilegeService(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<Models.UserPrivilege> Create(Models.UserPrivilege item)
    {
        dataContext.UserPrivileges.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<Models.UserPrivilege?> Delete(int id)
    {
        var privilege = await dataContext.UserPrivileges.FindAsync(id);

        if (privilege == null)
            return null;

        dataContext.UserPrivileges.Remove(privilege);

        await dataContext.SaveChangesAsync();

        return privilege;
    }

    public async Task<List<Models.UserPrivilege>> GetAll()
    {
        return await dataContext.UserPrivileges.ToListAsync();
    }

    public async Task<Models.UserPrivilege?> GetById(int id)
    {
        var privilege = await dataContext.UserPrivileges.FindAsync(id);

        if (privilege == null)
            return null;

        return privilege;
    }

    public async Task<Models.UserPrivilege?> Update(int id, Models.UserPrivilege item)
    {
        var privilege = await dataContext.UserPrivileges.FindAsync(id);

        if (privilege == null)
            return null;

        privilege.Name = item.Name;

        await dataContext.SaveChangesAsync();

        return privilege;
    }
}
