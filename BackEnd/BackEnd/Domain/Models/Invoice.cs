using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NameCli { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string IdCli { get; set; }

        public DateTime DateReg { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double Total { get; set; }


        public int UserId { get; set; }

        public Usersys User { get; set; }

        public List<Invoice_Detail> Invoice_Detail { get; set; }


    }
}
