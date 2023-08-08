namespace GymAPI.Models;

public class Exercise {
    public int Id { get; set;}
    public string Name { get; set;} = string.Empty;
    public string Description { get; set;} = string.Empty;
    public MuscleGroup MuscleGroup { get; set;} = new MuscleGroup();
    public string ExampleImageURI {get; set;} = string.Empty;
    public string ExampleVideoURI {get; set;} = string.Empty;

}