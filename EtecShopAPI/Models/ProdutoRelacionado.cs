using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EtecShopAPI.Models
{
    [Table("ProdutoRelacionado")]
    public class ProdutoRelacionado
    {
        [Key, Column(Order = 1)]
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }


        [Key, Column(Order = 2)]
        public int ProdutoSimilarId { get; set; }
        [ForeignKey("ProdutoSimilarId")]
        public Produto Similar { get; set; }
    }
}
