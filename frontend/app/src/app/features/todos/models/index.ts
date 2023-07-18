export type TodoListItemModel = {
    id: string;
    description: string;
    status: "Later" | "Now" | "Waiting" | "Completed"
}