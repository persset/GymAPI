using System.Data.Entity;
using GymAPI.Data;

namespace GymAPI.Services.UserType;

public class UserTypeService : IUserTypeService
{
    private readonly DataContext dataContext;

    public UserTypeService(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<Models.UserType> Create(Models.UserType item)
    {
        dataContext.UserTypes.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<Models.UserType?> Delete(int id)
    {
        var userType = await dataContext.UserTypes.FindAsync(id);

        if (userType == null)
            return null;

        dataContext.UserTypes.Remove(userType);

        await dataContext.SaveChangesAsync();

        return userType;
    }

    public async Task<List<Models.UserType>> GetAll()
    {
        return await dataContext.UserTypes.ToListAsync();
    }

    public async Task<Models.UserType?> GetById(int id)
    {
        var userType = await dataContext.UserTypes.FindAsync(id);

        if (userType == null)
            return null;

        return userType;
    }

    public async Task<Models.UserType?> Update(int id, Models.UserType item)
    {
        var userType = await dataContext.UserTypes.FindAsync(id);

        if (userType == null)
            return null;

        userType.Name = item.Name;
        userType.Privileges = item.Privileges;

        await dataContext.SaveChangesAsync();

        return userType;
    }
}
