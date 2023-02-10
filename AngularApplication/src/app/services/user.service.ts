import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private usersUrl = '/api/users';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }; 

  constructor(private http: HttpClient) { }

  addUser(user: User): Observable<boolean> {
    var subject = new Subject<boolean>();

    this.http
      .post<User>(this.usersUrl, user, this.httpOptions)
      .subscribe(
        data => subject.next(true),
        error => {
          this.handleError(error);
          subject.next(false);
        }
      );

    return subject.asObservable();
  }

  private handleError(err: any) {
      console.error(err);
  }
}
