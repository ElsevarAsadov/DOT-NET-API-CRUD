using API_Task.Entities.Bases;

namespace API_Task.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public string CostPrice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
