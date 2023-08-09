using System.Data.Entity;
using GymAPI.Data;

namespace GymAPI.Services.PlanPeriodicity;

public class PlanPeriodicityService : IPlanPeriodicityService
{
    private readonly DataContext dataContext;

    public PlanPeriodicityService(DataContext dataContext) {
        this.dataContext = dataContext;
    }
    public async Task<Models.PlanPeriodicity> Create(Models.PlanPeriodicity item)
    {
        dataContext.PlanPeriodicities.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<Models.PlanPeriodicity?> Delete(int id)
    {
        var planPeriodicity = await dataContext.PlanPeriodicities.FindAsync(id);

        if(planPeriodicity is null) return null;

        dataContext.PlanPeriodicities.Remove(planPeriodicity);

        await dataContext.SaveChangesAsync();

        return planPeriodicity;
    }

    public async Task<List<Models.PlanPeriodicity>> GetAll()
    {
        return await dataContext.PlanPeriodicities.ToListAsync();
    }

    public async Task<Models.PlanPeriodicity?> GetById(int id)
    {
        var planPeriodicity = await dataContext.PlanPeriodicities.FindAsync(id);

        if(planPeriodicity == null) return null;

        return planPeriodicity;
    }

    public async Task<Models.PlanPeriodicity?> Update(int id, Models.PlanPeriodicity item)
    {
        var planPeriodicity = await dataContext.PlanPeriodicities.FindAsync(id);

        if(planPeriodicity == null) return null;

        dataContext.Entry(planPeriodicity).CurrentValues.SetValues(item);

        await dataContext.SaveChangesAsync();

        return planPeriodicity;
    }
}
