import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { List } from '../models/list.model';

@Injectable({
  providedIn: 'root'
})
export class ListService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getList(listId: number) {

  }

  getLists(userId: number): Observable<List[]> {
    return this.http.get<List[]>(this.baseUrl + "list/" + userId);
  }

  createList(title: string, userId: number): Observable<List> {
    return this.http.post<List>(this.baseUrl + "list", { name: title, userId });
  }

  updateList(listId: number, title: string): Observable<List> {
    return this.http.put<List>(this.baseUrl + "list/" + listId, { name: title });
  }

  deleteList(listId: number) {
    return this.http.delete(this.baseUrl + "list/" + listId);
  }
}
