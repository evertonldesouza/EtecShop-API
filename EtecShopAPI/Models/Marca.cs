using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EtecShopAPI.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength (30)]
        public string Nome { get; set; }
    }
}
