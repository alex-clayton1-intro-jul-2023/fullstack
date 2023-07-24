
using Marten;

namespace TodosApi.Controllers;
[ApiController] // automatically validates whether or not things are valid

public class TodoListController : ControllerBase
{

    private readonly IManageTheTodoListCatalog _todoListCatalog;

    public TodoListController(IManageTheTodoListCatalog todoListCatalog)
    {
        _todoListCatalog = todoListCatalog;
    }



    [HttpPost("/todo-list")]
    public async Task<ActionResult> AddTodoItem([FromBody] TodoListCreateModel request)
    {

        // Turn the request into a TodoListItemResponseModel, then send it back
        // If we get here, this is valid
        // Add it to the database
 
        TodoListItemResponseModel response = await _todoListCatalog.AddTodoItemAsync(request);
        return Ok(response);
    }

    // GET /todo-list
    [HttpGet("/todo-list")] // Attribute to get it
    public async Task<ActionResult> GetTodoList()
    {
        CollectionResponse<TodoListItemResponseModel> list = await _todoListCatalog.GetFullListAsync();
        return Ok(list);
    }
}

