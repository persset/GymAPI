using GymAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Services.Functionary;

public class FunctionaryService : IFunctionaryService
{
    private readonly DataContext dataContext;

    public FunctionaryService(DataContext dataContext) {
        this.dataContext = dataContext;
    }
    public async Task<Models.Functionary> Create(Models.Functionary item)
    {
         dataContext.Functionaries.Add(item);

         await dataContext.SaveChangesAsync();

         return item;
    }

    public async Task<Models.Functionary?> Delete(int id)
    {
        var functionary = await dataContext.Functionaries.FindAsync(id);

        if(functionary is null) return null;

        dataContext.Functionaries.Remove(functionary);
        
        await dataContext.SaveChangesAsync();

        return functionary;
    }

    public async Task<List<Models.Functionary>> GetAll()
    {
        return await dataContext.Functionaries.ToListAsync();
    }

    public async Task<Models.Functionary?> GetById(int id)
    {
        var functionary = await dataContext.Functionaries.FindAsync(id);

        if(functionary is null) return null;

        return functionary;
    }

    public async Task<Models.Functionary?> Update(int id, Models.Functionary item)
    {
        var functionary = await dataContext.Functionaries.FindAsync(id);

        if(functionary is null) return null;

        dataContext.Entry(functionary).CurrentValues.SetValues(item);

        await dataContext.SaveChangesAsync();

        return functionary;
    }
}