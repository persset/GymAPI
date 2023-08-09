using GymAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Services.Client;

public class ClientService : IClientService
{
    private readonly DataContext dataContext;

    public ClientService(DataContext dataContext) {
        this.dataContext = dataContext;
    }

    public async Task<Models.Client> Create(Models.Client item)
    {
        dataContext.Clients.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<Models.Client?> Delete(int id)
    {
        var client = await dataContext.Clients.FindAsync(id);

        if(client is null) return null;

        return client;
    }

    public async Task<List<Models.Client>> GetAll()
    {
        return await dataContext.Clients.ToListAsync();
    }

    public async Task<Models.Client?> GetById(int id)
    {
        var client = await dataContext.Clients.FindAsync(id);

        if(client is null) return null;

        return client;
    }

    public async Task<Models.Client?> Update(int id, Models.Client item)
    {
        var client = await dataContext.Clients.FindAsync(id);

        if(client is null) return null;

        client.Name = item.Name;
        client.User = item.User;
        client.Phone = item.Phone;
        client.Plan = item.Plan;
        client.SubscriptionDeadline = item.SubscriptionDeadline;

        await dataContext.SaveChangesAsync();

        return client;
    }
}