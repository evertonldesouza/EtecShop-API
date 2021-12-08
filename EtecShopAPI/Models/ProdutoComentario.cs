using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EtecShopAPI.Models
{
    [Table("ProdutoComentario")]
    public class ProdutoComentario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [StringLength(1000)]
        public string Comentario { get; set; }
        public DateTime DataComentario { get; set; } = DateTime.Now;
        public byte? Nota { get; set; }
    }
}
