namespace TaskManager.Server.Core.Tasks
{
    public record AddTaskInput(
        string Title,
        string? Description,
        DateTime? DueDate,
        int CreatedUserId,
        int? AssigneeId,
        int StatusId,
        DateTime DateCreated);
}
