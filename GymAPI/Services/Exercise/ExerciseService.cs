using GymAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Services.Exercise;

public class ExerciseSevice : IExerciseService
{
    private readonly DataContext dataContext;

    public ExerciseSevice(DataContext dataContext) {
        this.dataContext = dataContext;
    }
    public async Task<Models.Exercise> Create(Models.Exercise item)
    {
        dataContext.Exercises.Add(item);

        await dataContext.SaveChangesAsync();

        return item;
    }

    public async Task<Models.Exercise?> Delete(int id)
    {
        var exercise = await dataContext.Exercises.FindAsync(id);

        if(exercise is null) return null;

        dataContext.Exercises.Remove(exercise);

        await dataContext.SaveChangesAsync();

        return exercise;
    }

    public async Task<List<Models.Exercise>> GetAll()
    {
        return await dataContext.Exercises.ToListAsync();
    }

    public async Task<Models.Exercise?> GetById(int id)
    {
        var exercise = await dataContext.Exercises.FindAsync(id);

        if(exercise is null) return null;

        return exercise;
    }

    public async Task<Models.Exercise?> Update(int id, Models.Exercise item)
    {
        var exercise = await dataContext.Exercises.FindAsync(id);

        if(exercise is null) return null;

        exercise.Name = item.Name;
        exercise.Description = item.Description;
        exercise.MuscleGroup = item.MuscleGroup;
        exercise.ExampleImageURI = item.ExampleImageURI;
        exercise.ExampleVideoURI = item.ExampleVideoURI;

        await dataContext.SaveChangesAsync();

        return exercise;
    }
}