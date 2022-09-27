namespace TodoApp.Models
{
    public class Todo {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}