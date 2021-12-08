using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EtecShopAPI.Models
{
    [Table("ProdutoCategoria")]
    public class ProdutoCategoria
    {
        [Key,Column(Order =1)]        
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        
        [Key, Column(Order = 2)]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
