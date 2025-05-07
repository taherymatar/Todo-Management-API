using System.ComponentModel.DataAnnotations;
using TodoManagementAPI.Core.Enums;

namespace TodoManagementAPI.Data.Models
{
    public class Todo
    {
        public Todo()
        {
            Status  = TodoStatus.Pending;
        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public TodoStatus Status { get; set; }
        public TodoPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; }
    }
}
