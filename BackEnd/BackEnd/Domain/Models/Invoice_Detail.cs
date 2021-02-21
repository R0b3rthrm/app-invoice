using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Invoice_Detail
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string NamePro { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double PricePro { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
