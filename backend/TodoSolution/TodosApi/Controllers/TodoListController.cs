﻿

using Marten;

namespace TodosApi.Controllers;

[ApiController]
public class TodoListController : ControllerBase
{

    private readonly IManageTheTodoListCatalog _todoListCatalog;

    public TodoListController(IManageTheTodoListCatalog todoListCatalog)
    {
        this._todoListCatalog = todoListCatalog;
    }

    [HttpPost("/todo-list")]
    public async Task<ActionResult> AddTodoItem([FromBody] TodoListCreateModel request)
    {
        var response = await _todoListCatalog.AddTodoItemAsync(request);
        return Ok(response);
    }

    // Post /todo-list-status-change
    [HttpPost("/todos-list-status-change")]
    public async Task<ActionResult> changeTheStatusOf([FromBody] TodoListItemRequestModel request)
    {
        // do something
        // run something

        TodoListItemResponseModel? response = await _todoListCatalog.ChangeStatusAsync(request);

        if (response == null)
        {
            return BadRequest("No item with that Id to change the status of");
        } else
        {
            return Ok(request);
        }
    }



    // GET /todo-list
    [HttpGet("/todo-list")]
    public async Task<ActionResult> GetTodoList()
    {
        var list = await _todoListCatalog.GetFullListAsync();
        return Ok(list);
    }
}