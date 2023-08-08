namespace GymAPI.Models;

public class TrainingExercises {
    public int TrainingId { get; set; }
    public int ExerciseId { get; set; }
    public TrainingOrganization TrainingOrganization { get; set; } = new();
}