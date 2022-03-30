import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    return this.http.post<User>(this.baseUrl + "account/login", { email, password }).pipe(
      map((response: User) => {
        var user = response;
        if (user) {
          this.setCurrentUser(user);
        }
      })
    );
  }

  signup(email: string, password: string) {
    return this.http.post<User>(this.baseUrl + "account/register", { email, password }).pipe(
      map((response: User) => {
        var user = response;
        if (user) {
          this.setCurrentUser(user);
        }
      })
    );
  }

  addAdmin(email: string, password: string): Observable<User> {
    return this.http.post<User>(this.baseUrl + "account/register-admin", { email, password });
  }

  deleteAccount(userId: number, password: string) {
    return this.http.delete(this.baseUrl + "account/delete/" + userId, { body: { id: userId, password } });
  }

  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + "account/delete-user/" + id);
  }

  setCurrentUser(user: User | null) {
    if (user) this.setSession(user);
    this.currentUserSource.next(user);
  }

  logout() {
    this.removeSession();
    this.currentUserSource.next(null);
  }

  setSession(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  removeSession() {
    localStorage.removeItem('user');
  }

  changePassword(oldPassword: string, password: string, id: number) {
    return this.http.put(this.baseUrl + "account/update-password/" + id, { id, password, oldPassword });
  }
}
