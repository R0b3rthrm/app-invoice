import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usersys } from 'src/app/models/usersys';
import { UsersysService } from 'src/app/services/usersys.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  register:FormGroup;
  loading =false;

  constructor(private fb:FormBuilder, private route:Router, private  usersysService: UsersysService, private toastr: ToastrService) {
      this.register = this.fb.group({
      user:['',Validators.required],
      pass:['',[Validators.required,Validators.minLength(6)]],
      confPass:[''],
      email:['',[ Validators.required, Validators.email]]
      
    }, {
      validators:this.checkPassword
    })


   }

   get fg(){
    return this.register.controls;
  }



  ngOnInit(): void {
  }

  regUser ():void{
    
    this.loading=true;;
    const usersys: Usersys ={
      NameUser : this.register.value.user,
      PassUser : this.register.value.pass,
      EmailUser : this.register.value.email
    }


    this.usersysService.saveUser(usersys).subscribe( data=>{
      this.toastr.success('El usuario '+usersys.NameUser+' se registro correctamente','Usuario Registrado');
      this.loading=false;
      this.route.navigate(["/Inicio/Login"]);
    }, error=>{
        this.loading =false;
        this.register.reset();
        this.toastr.error(error.error.message,"error");
    });

  }

  checkPassword(group: FormGroup): any{
    const pass = group.controls.pass.value;
    const confPass = group.controls.confPass.value;
    return pass == confPass ? null:{notSame:true};
  }


}
