using System.ComponentModel.DataAnnotations;

namespace TodosApi.Models;


public enum TodoItemStatus { Later, Now, Waiting, Completed } // 0/1/2/3 but assigned to strings
public record TodoListItemResponseModel(Guid Id, string Description, TodoItemStatus Status);


public record TodoListCreateModel
{
    [Required, MaxLength(100)]
    public string Description { get; set; } = string.Empty;
}