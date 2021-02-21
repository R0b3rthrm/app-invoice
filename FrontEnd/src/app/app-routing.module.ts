import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LsitInvoiceComponent } from './components/dashboard/lsit-invoice/lsit-invoice.component';
import { NewInvoiceComponent } from './components/dashboard/new-invoice/new-invoice.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { LoginComponent } from './components/inicio/login/login.component';
import { RegisterComponent } from './components/inicio/register/register.component';

const routes: Routes = [
  {path: '',redirectTo:'inicio/login', pathMatch:'full'},
  {path: 'Inicio',redirectTo:'inicio/login', pathMatch:'full'},
  {path: 'inicio', component:InicioComponent, children:[
    {path:'login', component:LoginComponent},
    {path:'register', component:RegisterComponent}
  ]},
  {path: 'dashboard',redirectTo:'dashboard/listInvoice', pathMatch:'full'},
  {path:'dashboard',component:DashboardComponent, children:[
    {path:'newInvoice', component:NewInvoiceComponent},
    {path:'listInvoice', component:LsitInvoiceComponent},
  ]},
  {path:'**', redirectTo: 'inicio/login', pathMatch:'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
