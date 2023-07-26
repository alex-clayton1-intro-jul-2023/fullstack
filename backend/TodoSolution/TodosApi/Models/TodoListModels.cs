using System.ComponentModel.DataAnnotations;

namespace TodosApi.Models;


public enum TodoItemStatus { Later, Now, Waiting, Completed } // 0/1/2/3 but assigned to strings
public record TodoListItemResponseModel(Guid Id, string Description, TodoItemStatus Status); // Comes from the server

public record TodoListItemRequestModel
{
    [Required]
    public Guid Id { get; set; }
    [Required, MaxLength(100)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public TodoItemStatus? Status { get; set; } // ? is equal to saying "nullable"
}


public record TodoListCreateModel
{
    [Required, MaxLength(100)]
    public string Description { get; set; } = string.Empty;
}