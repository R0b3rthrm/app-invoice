import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usersys } from  '../models/usersys';


@Injectable({
  providedIn: 'root'
})
export class UsersysService {

  myAppUrl:string;
  myApiUrl:string;

  constructor(private http: HttpClient)  {
    this.myAppUrl=environment.endPoint;
    this.myApiUrl='/api/User';

  } 


  saveUser(usersys: Usersys):Observable<any>{
    return this.http.post(this.myAppUrl+this.myApiUrl, usersys);
  }

}
