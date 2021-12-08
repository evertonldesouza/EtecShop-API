using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EtecShopAPI.Models
{
    [Table("ProdutoFoto")]
    public class ProdutoFoto
    {
        public int Id { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required]
        [StringLength(200)]
        public string Arquivo { get; set; }

        [Required]
        [StringLength(100)]
        public string Legenda { get; set; }
    }
}
