namespace GymAPI.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserPrivilege> Privileges { get; set; } = new List<UserPrivilege>();
    }
}
