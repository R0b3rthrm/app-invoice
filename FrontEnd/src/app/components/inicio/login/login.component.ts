import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usersys } from 'src/app/models/usersys';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loading =false;
  login: FormGroup;

  constructor(private fb: FormBuilder, private router:Router, private loginService:LoginService, private toastr: ToastrService) {
    this.login = this.fb.group({
      user:['',Validators.required],
      pass:['',Validators.required]
      
    })
  }

  
  get fg(){
    return this.login.controls;
  }

  ngOnInit(): void {
  }
  
  log():void{

    this.loading=true;

    const usersys: Usersys ={
      NameUser : this.login.value.user,
      PassUser : this.login.value.pass,
      EmailUser: '',
    }
    
    this.loginService.login(usersys).subscribe(data=>{
      console.log(data);
      this.loading =false;
      this.loginService.setLocalStorage(data.token);
      this.router.navigate(["/dashboard"]);

    }, error=>{
      this.loading =false;
      this.login.reset();
      this.toastr.error(error.error.message,"error");

    
    })
    console.log(this.login);

  }

}
