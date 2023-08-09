using System.Data.Entity;
using GymAPI.Data;

namespace GymAPI.Services.Training;

public class TrainingService : ITrainingService
{
    private readonly DataContext dataContext;

    public TrainingService(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<Models.Training> Create(Models.Training item)
    {
        dataContext.Trainings.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<Models.Training?> Delete(int id)
    {
        var training = await dataContext.Trainings.FindAsync(id);

        if (training == null)
            return null;

        dataContext.Trainings.Remove(training);

        await dataContext.SaveChangesAsync();

        return training;
    }

    public async Task<List<Models.Training>> GetAll()
    {
        return await dataContext.Trainings.ToListAsync();
    }

    public async Task<Models.Training?> GetById(int id)
    {
        var training = await dataContext.Trainings.FindAsync(id);

        if (training == null)
            return null;

        return training;
    }

    public async Task<Models.Training?> Update(int id, Models.Training item)
    {
        var training = await dataContext.Trainings.FindAsync(id);

        if (training == null)
            return null;

        training.Client = item.Client;
        training.TrainingDesigner = item.TrainingDesigner;

        await dataContext.SaveChangesAsync();

        return training;
    }
}
