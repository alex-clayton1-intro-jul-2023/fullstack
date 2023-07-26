namespace TodosApi;

public interface IProvideTheStatusCycling
{
    TodoListItemResponseModel ProvideNextStatusFrom(TodoListItemResponseModel savedItem);
}