namespace TodoManagementAPI.Core.ViewModels
{
    public class TodoViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string Status { get; set; } = default!;
        public string Priority { get; set; } = default!;
        public string? DueDate { get; set; }
        public string CreatedDate { get; set; } = default!;
        public string LastModifiedDate { get; set; } = default!;
    }
}
