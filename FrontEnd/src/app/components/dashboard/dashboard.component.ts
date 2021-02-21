import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Invoice } from 'src/app/models/invoice';
import { InvoiceService } from 'src/app/services/invoice.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  listDataInvoice : Invoice;  
  constructor(private invoicesrv : InvoiceService, private toastr:ToastrService, private route:Router) { }

  ngOnInit(): void {
    this.route.navigate(['dashboard/listInvoice']);
    //this.getListInvoice ();
  }


 


}
