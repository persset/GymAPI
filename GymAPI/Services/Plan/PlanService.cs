using System.Data.Entity;
using GymAPI.Data;

namespace GymAPI.Services.Plan;

public class PlanService : IPlanService
{
    private readonly DataContext dataContext;

    public PlanService(DataContext dataContext) {
        this.dataContext = dataContext;
    }
    public async Task<Models.Plan> Create(Models.Plan item)
    {
        dataContext.Plans.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<Models.Plan?> Delete(int id)
    {
        var plan = await dataContext.Plans.FindAsync(id);

        if(plan is null) return null;

        dataContext.Plans.Remove(plan);

        await dataContext.SaveChangesAsync();

        return plan;
    }

    public async Task<List<Models.Plan>> GetAll()
    {
        return await dataContext.Plans.ToListAsync();
    }

    public async Task<Models.Plan?> GetById(int id)
    {
        var plan = await dataContext.Plans.FindAsync(id);

        if(plan is null) return null;

        return plan;
    }

    public async Task<Models.Plan?> Update(int id, Models.Plan item)
    {
        var plan = await dataContext.Plans.FindAsync(id);

        if(plan is null) return null;

        dataContext.Entry(plan).CurrentValues.SetValues(item);

        await dataContext.SaveChangesAsync();

        return plan;
    }
}