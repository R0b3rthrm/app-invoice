export class Invoice_Detail{

    NamePro!: string;
    PricePro!: number;

    constructor(PricePro:number, NamePro: string ) {
        this.PricePro=PricePro;
        this.NamePro=NamePro;
    }

}