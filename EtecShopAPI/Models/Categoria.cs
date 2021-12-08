using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EtecShopAPI.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<ProdutoCategoria> Produtos { get; set; }
    }
}
