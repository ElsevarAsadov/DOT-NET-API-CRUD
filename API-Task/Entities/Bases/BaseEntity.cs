namespace API_Task.Entities.Bases
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set;}
    }
}
