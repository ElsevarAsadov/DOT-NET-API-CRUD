using System.ComponentModel.DataAnnotations;

namespace API_Task.DTOs.Category
{
    public class DTOCategoryUpdate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
