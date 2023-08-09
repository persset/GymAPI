using GymAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Services.MuscleGroup;

public class MuscleGroupService : IMuscleGroupService
{
    private readonly DataContext dataContext;

    public MuscleGroupService(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }
    public async Task<Models.MuscleGroup> Create(Models.MuscleGroup item)
    {
        dataContext.MuscleGroups.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<Models.MuscleGroup?> Delete(int id)
    {
        var muscleGroup = await dataContext.MuscleGroups.FindAsync(id);

        if (muscleGroup is null) return null;

        dataContext.MuscleGroups.Remove(muscleGroup);

        await dataContext.SaveChangesAsync();

        return muscleGroup;
    }

    public async Task<List<Models.MuscleGroup>> GetAll()
    {
        return await dataContext.MuscleGroups.ToListAsync();
    }

    public async Task<Models.MuscleGroup?> GetById(int id)
    {
        var muscleGroup = await dataContext.MuscleGroups.FindAsync(id);

        if (muscleGroup is null) return null;

        return muscleGroup;
    }

    public async Task<Models.MuscleGroup?> Update(int id, Models.MuscleGroup item)
    {
        var muscleGroup = await dataContext.MuscleGroups.FindAsync(id);

        if (muscleGroup is null) return null;

        dataContext.Entry(muscleGroup).CurrentValues.SetValues(item);

        await dataContext.SaveChangesAsync();

        return muscleGroup;
    }
}
