import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Invoice } from 'src/app/models/invoice';
import { InvoiceService } from 'src/app/services/invoice.service';
import {NgbModal, ModalDismissReasons} from "@ng-bootstrap/ng-bootstrap";
import { InvoiceDTO } from 'src/app/models/invoiceDTO';

@Component({
  selector: 'app-lsit-invoice',
  templateUrl: './lsit-invoice.component.html',
  styleUrls: ['./lsit-invoice.component.css']
})
export class LsitInvoiceComponent implements OnInit {
  
  typeModal :number;
  listDataInvoice : Invoice;  
  listViewInvoice : Invoice;  
  constructor( private invoicesrv : InvoiceService, private toastr:ToastrService, private route:Router, private modalService:NgbModal) { 
   
  }


  ngOnInit(): void {
    this.typeModal =0;

    this.getListInvoice();
  }

  getListInvoice() :void {
    this.invoicesrv.getListInvoice().subscribe(data=>{
      this.listDataInvoice = data;
      console.log('aqui datossssssss');
      console.log(this.listDataInvoice);
    });
  }

  removeInvoice(idInvoice):void{
    
    this.invoicesrv.deleteInvoice(idInvoice).subscribe(data=>{
      console.log("Elimino");
      console.log(data);
      this.toastr.success("Se elimino la factura Correctamente","Factura Eliminada");
      this.getListInvoice();
    },error=>{
      this.toastr.error("No se pudo borrar la Factura","Error");
    });
  }

  viewInvoice( content,typeModal, idInvoice):void{

    this.invoicesrv.getListInvoiceById(idInvoice).subscribe(data=>{
      this.typeModal=typeModal;
      this.modalService.open(content);
      this.listViewInvoice = data;
    });

  }

  updateInvoice(content, idInvoice):void{
     
    console.log(idInvoice);
    var nameCli = (<HTMLInputElement>document.getElementById('NameCli')).value;
    var idCli = (<HTMLInputElement>document.getElementById('IdCli')).value;
    
    if(nameCli != '' && nameCli != ''){

      const invoice_data : InvoiceDTO ={
        NameCli : nameCli,
        IdCli : idCli
      }

      this.invoicesrv.updateInvoice(idInvoice,invoice_data).subscribe(()=>{
        this.toastr.success("Se realizaron las modificaciones correctamente","Cambios Correctamente"),
        this.modalService.dismissAll(content);
        this.getListInvoice();
        

      }, error=>{
        this.toastr.error("Al actualizar los Cambios","error");
    });

    }else{
      this.toastr.warning("Los campos no pueden estar vacios", "Atencion");
    }

    console.log(nameCli);
  
  }

}
