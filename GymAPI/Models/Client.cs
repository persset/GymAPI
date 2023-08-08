namespace GymAPI.Models;

public class Client {
    public int Id { get; set;}
    public string Name { get; set;} = string.Empty;
    public string Phone { get; set;} = string.Empty;
    public User User { get; set;} = new User();
    public Plan Plan { get; set; } = new Plan();
    public DateTime SubscriptionDeadline { get; set; } = new DateTime();
}