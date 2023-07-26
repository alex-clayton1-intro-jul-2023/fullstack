namespace TodosApi;

public class StatusCycler : IProvideTheStatusCycling
{
    public TodoListItemResponseModel ProvideNextStatusFrom(TodoListItemResponseModel savedItem)
    {

        if (savedItem.Status == TodoItemStatus.Completed)
        {
            return savedItem with { Status = TodoItemStatus.Later };
        }
        return savedItem with { Status = savedItem.Status + 1};
    }
}



// Later -> Now -> Waiting -> Completed -> Later