import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Task } from 'src/app/models/task.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTask(taskId: number): Observable<Task> {
    return this.http.get<Task>(this.baseUrl + "task/one/" + taskId);
  }

  getTasks(listId: number): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseUrl + "task/tasks/" + listId);
  }

  createTask(text: string, listId: number): Observable<Task> {
    return this.http.post<Task>(this.baseUrl + "task", { text: text, listId: listId });
  }

  updateTaskStatus(taskId: number): Observable<Task> {
    return this.http.put<Task>(this.baseUrl + "task/status/" + taskId, {});
  }

  updateTask(taskId: number, text: string): Observable<Task> {
    return this.http.put<Task>(this.baseUrl + "task/task/" + taskId, { id: taskId, text });
  }

  deleteTask(taskId: number) {
    return this.http.delete(this.baseUrl + "task/" + taskId);
  }
}
