import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usersys } from '../models/usersys';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  myAppUrl:string;
  myApiUrl:string;
  
  constructor(private http: HttpClient, private route:Router,
    private toastr: ToastrService) { 
    this.myAppUrl=environment.endPoint;
    this.myApiUrl='/api/Login';

  }

  login(usersys:Usersys):Observable<any>{
    return this.http.post(this.myAppUrl+this.myApiUrl, usersys);
    
  }

  setLocalStorage(data):void{
    localStorage.setItem('token',data);
  }

  ///getLocalStorage(data):void{
  ///  return localStorage.setItem('',data);
  ///}

  getTokenDecode(): any{
    const helper = new JwtHelperService();
    const decodedToken = helper.decodeToken(localStorage.getItem('token'));
    return decodedToken;
  }

  removeLocalStorage():void{
    localStorage.removeItem('token');
  }
}
