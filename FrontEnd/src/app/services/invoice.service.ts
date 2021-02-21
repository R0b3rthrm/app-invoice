import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Invoice } from '../models/invoice';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  myAppUrl:string;
  myApiUrl:string;
  
  constructor(private http: HttpClient) 
  {
    this.myAppUrl=environment.endPoint;
    this.myApiUrl='/api/Invoice';

   }

   saveInvoice (invoice: Invoice): Observable<any>{
      return this.http.post(this.myAppUrl+ this.myApiUrl,invoice);
   }

   getListInvoice ():Observable<any>{
    return this.http.get(this.myAppUrl+ this.myApiUrl+'/GetListInvoice');

   }
   
   getListInvoiceById (idInvoice):Observable<any>{
    return this.http.get(this.myAppUrl+ this.myApiUrl+'/'+idInvoice);

   }

   deleteInvoice(idInvoice):Observable<any>{
    return this.http.delete(this.myAppUrl+ this.myApiUrl+'/'+idInvoice);
   }
   

   updateInvoice(idInvoice, invoiceDTO):Observable<any>{
    return this.http.put(this.myAppUrl+ this.myApiUrl+'/'+idInvoice,invoiceDTO);
   }
   
   
}
