using GymAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Services.User;

public class UserService : IUserService
{
    private readonly DataContext dataContext;

    public UserService(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }
    public async Task<Models.User> Create(Models.User item)
    {
        dataContext.Users.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<Models.User?> Delete(int id)
    {
        var user = await dataContext.Users.FindAsync(id);

        if (user is null) return null;

        dataContext.Users.Remove(user);
        await dataContext.SaveChangesAsync();

        return user;
    }

    public async Task<List<Models.User>> GetAll()
    {
        return await dataContext.Users.ToListAsync();
    }

    public async Task<Models.User?> GetById(int id)
    {
        var user = await dataContext.Users.FindAsync(id);

        if (user is null) return null;

        return user;
    }

    public async Task<Models.User?> Update(int id, Models.User item)
    {
        var user = await dataContext.Users.FindAsync(id);

        if (user is null) return null;

        user.Username = item.Username;
        user.Password = item.Password;
        user.UserType = item.UserType;

        await dataContext.SaveChangesAsync();

        return user;
    }
}