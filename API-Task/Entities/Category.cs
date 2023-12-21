using API_Task.Entities.Bases;

namespace API_Task.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        List<Book> Books { get; set; }

        
       
    }
}
