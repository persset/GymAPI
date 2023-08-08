namespace GymAPI.Models;

public class MuscleGroup {
    public int Id { get; set;}
    public string Name { get; set; } = string.Empty;
    public ICollection<Exercise> Exercises {get;} = new List<Exercise>();
}