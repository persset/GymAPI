namespace GymAPI.Models {
    public class Customer {
        public Customer() {
            this.Routines = new HashSet<Routine>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime SubscriptionDeadline { get; set; }
        public virtual ICollection<Routine>? Routines { get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
