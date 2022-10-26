namespace GymAPI.Models {
    public class Routine {
        public Routine() {
            this.Exercises = new HashSet<Exercise>();
        }

        public int Id { get; set; }
        public ICollection<Exercise>? Exercises { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
