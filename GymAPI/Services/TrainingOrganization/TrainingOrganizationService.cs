using System.Data.Entity;
using GymAPI.Data;
using GymAPI.Models;

namespace GymAPI.Services.TrainingOrganizaton;

public class TrainingOrganizationService : ITrainingOrganizationService
{
    private readonly DataContext dataContext;

    public TrainingOrganizationService(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<TrainingOrganization> Create(TrainingOrganization item)
    {
        dataContext.TrainingsOrganizations.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<TrainingOrganization?> Delete(int id)
    {
        var trainingOrg = await dataContext.TrainingsOrganizations.FindAsync(id);

        if (trainingOrg == null)
            return null;

        dataContext.TrainingsOrganizations.Remove(trainingOrg);

        await dataContext.SaveChangesAsync();

        return trainingOrg;
    }

    public async Task<List<TrainingOrganization>> GetAll()
    {
        return await dataContext.TrainingsOrganizations.ToListAsync();
    }

    public async Task<TrainingOrganization?> GetById(int id)
    {
        var trainingOrg = await dataContext.TrainingsOrganizations.FindAsync(id);

        if (trainingOrg == null)
            return null;

        return trainingOrg;
    }

    public async Task<TrainingOrganization?> Update(int id, TrainingOrganization item)
    {
        var trainingOrg = await dataContext.TrainingsOrganizations.FindAsync(id);

        if (trainingOrg == null)
            return null;

        dataContext.Entry(trainingOrg).CurrentValues.SetValues(item);

        await dataContext.SaveChangesAsync();

        return trainingOrg;
    }
}
