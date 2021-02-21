import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Invoice } from 'src/app/models/invoice';
import { InvoiceService } from 'src/app/services/invoice.service';
import { Invoice_Detail } from 'src/app/models/invoice_detail';

@Component({
  selector: 'app-new-invoice',
  templateUrl: './new-invoice.component.html',
  styleUrls: ['./new-invoice.component.css']
})

export class NewInvoiceComponent implements OnInit {

  
  invoice:FormGroup;
  valTotal :number;

  constructor(private fb:FormBuilder,private toastr: ToastrService, private invoicesrv : InvoiceService, private route: Router) {
      this.invoice= this.fb.group({
            NameCli: ['',Validators.required],
            IdCli: ['',Validators.required],
            Invoice_Detail: this.fb.array([])
    })
  }


  ngOnInit(): void {
    this.addDefaultInvoice_Detail();
  }


  //DEVUELVE FORMARRAY DE REPUESTAS
  get getInvoice_Detail():FormArray{
      return this.invoice.get('Invoice_Detail') as FormArray;
  }
  //AGREGAR RESPUESTA ARRAY
  addInvoice_Detail(): void{
    this.getInvoice_Detail.push(this.fb.group({
      NamePro:['',Validators.required],
      PricePro:['', Validators.required] 
    }));
  }

  sumValTol(): void {  
    this.valTotal = 0;
    var arrValuers: Array<string> = this.invoice.value.Invoice_Detail;
    arrValuers.forEach(element => {
      
      if(element['PricePro'] != "")
          this.valTotal+=Number(element['PricePro']);
      
    });

  }


  addDefaultInvoice_Detail():void{
    this.addInvoice_Detail();
  }

  removeInvoice_Detail(index: number):void{
    this.getInvoice_Detail.removeAt(index);
    this.sumValTol();  
  }
  

  SaveInvoice():void{

    this.sumValTol();
    const  listInvoice_Detail : Invoice_Detail[] = [];

    this.invoice.value.Invoice_Detail.forEach(element => {
      const InvoiceDetailData = new Invoice_Detail (element.PricePro, element.NamePro);
      listInvoice_Detail.push(InvoiceDetailData)
    
    });
    
    const invoice_data = new Invoice (
        this.invoice.value.NameCli,
        this.invoice.value.IdCli,
        this.valTotal,
        listInvoice_Detail
    );


    console.log(invoice_data);

     this.invoicesrv.saveInvoice(invoice_data).subscribe(()=>{
       this.toastr.success("Factura registrada correctamente","Factura Registrada"),
       this.route.navigate(["/dashboard/listInvoice"]);
    }, error=>{
      // this.invoice.reset();
       this.toastr.error("La factura no pudo ser registrada","error");
   });

  }

}
