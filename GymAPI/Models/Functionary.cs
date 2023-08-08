namespace GymAPI.Models;

public class Functionary {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public User User { get; set; } = new User();
}