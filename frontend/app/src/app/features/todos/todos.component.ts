import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './components/list/list.component';
import { EntryComponent } from './components/entry/entry.component';
import { TodoListEntryModel, TodoListItemModel } from './models';

@Component({
  selector: 'app-todos',
  standalone: true,
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css'],
  imports: [CommonModule, ListComponent, EntryComponent],
})
export class TodosComponent {
  todoList: TodoListItemModel[] = [
    {
      id: '1',
      description: 'Buy Beer',
      status: 'Now',
    },
  ];

  addItem(candidate: TodoListEntryModel) {
    // send it to the API, when it returns
    // POST http:/api.com/todolist
    const newItem: TodoListItemModel = {
      id: '99',
      description: candidate.description,
      status: 'Later',
    };
    this.todoList = [newItem, ...this.todoList];
  }
}
