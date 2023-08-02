namespace GymAPI.Models
{
    public class UserPrivilege
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserType> UserTypes { get; set; } = new List<UserType>();
    }
}
