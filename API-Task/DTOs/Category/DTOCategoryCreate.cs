using System.ComponentModel.DataAnnotations;

namespace API_Task.DTOs.Category
{
    public class DTOCategoryCreate
    {
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Name must have at least 1 character")]
        public string Name { get; set; }
    }
}
