using System.ComponentModel.DataAnnotations;
using TodoManagementAPI.Core.Enums;

namespace TodoManagementAPI.Core.Dtos
{
    public class CreateTodoDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }

        [EnumDataType(typeof(TodoPriority))]
        public TodoPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
