namespace API_Task.DTOs.Book
{
    public class DTOBookCreate
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public double CostPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
