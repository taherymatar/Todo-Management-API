using System.ComponentModel.DataAnnotations;
using TodoManagementAPI.Core.Enums;

namespace TodoManagementAPI.Core.Dtos
{
    public class UpdateTodoDto
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        [EnumDataType(typeof(TodoStatus))]
        public TodoStatus Status { get; set; }

        [EnumDataType(typeof(TodoPriority))]
        public TodoPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
