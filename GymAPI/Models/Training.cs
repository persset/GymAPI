namespace GymAPI.Models;

public class Training {
    public int Id { get; set; }
    public Client Client {get; set;} = new Client();
    public Functionary TrainingDesigner {get; set;} = new Functionary();
}