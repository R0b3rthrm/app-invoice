using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.Models
{
    public class Usersys
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NameUser { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string PassUser { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string EmailUser { get; set; }
    }
}
