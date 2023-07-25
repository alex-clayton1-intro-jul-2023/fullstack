export type TodoListItemModel = {
  id: string;
  description: string;
  status: TodoListItemStatus;
};

export type TodoListEntryModel = Pick<TodoListItemModel, 'description'>; // Picks a todolistitemmodel type that only has a description ("string")

export type TodoListItemStatus = 'Later' | 'Now' | 'Waiting' | 'Completed';
