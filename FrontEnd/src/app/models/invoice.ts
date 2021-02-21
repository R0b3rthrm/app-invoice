import {Invoice_Detail} from './invoice_detail'

export class Invoice{

    NameCli : string;
    
    IdCli : string;

    Total : number;
    
    Invoice_Detail : Invoice_Detail[];
    
    constructor(NameCli : string, IdCli : string,Total : number,Invoice_Detail : Invoice_Detail[]) {
        this.NameCli =NameCli;
    
        this.IdCli =IdCli;
    
        this.Total =Total;
        
        this.Invoice_Detail =Invoice_Detail;
    }

}