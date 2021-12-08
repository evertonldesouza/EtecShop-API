using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EtecShopAPI.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(1000)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(8000)]
        public string Detalhes { get; set; }
        [Required]
        [Range(1.0, 100000)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Preco { get; set; }
        [Required]
        [Range(0, 100000)]
        [Column(TypeName = "int(6)")]
        public int Estoque { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        [Required]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        [JsonIgnore]
        public ICollection<ProdutoFoto> Fotos { get; set; }
        [JsonIgnore]
        public ICollection<ListaDesejo> ClientesInteressados { get; set; }
        [JsonIgnore]
        public ICollection<ProdutoComentario> Comentarios { get; set; }
        [JsonIgnore]
        public ICollection<ProdutoRelacionado> Similares { get; set; }
        [JsonIgnore]
        public ICollection<ProdutoRelacionado> Relacionados { get; set; }
        [JsonIgnore]
        public ICollection<ProdutoCategoria> Categorias { get; set; }

    }
}
