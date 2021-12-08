using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EtecShopAPI.Models
{
    [Table("ListaDesejo")]
    public class ListaDesejo
    {
        [Key, Column(Order =1)]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Key, Column(Order = 2)]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
