using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EtecShopAPI.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(8)]
        public string Cep { get; set; }
        [Required]
        [StringLength(60)]
        public string Endereco { get; set; }        
        [Required]
        [StringLength(10)]
        public string Numero { get; set; }
        [Required]
        [StringLength(30)]
        public string Complemento { get; set; }
        [Required]
        [StringLength(30)]
        public string Bairro { get; set; }
        [Required]
        [StringLength(30)]
        public string Cidade { get; set; }
        [Required]
        [StringLength(2)]
        public string Estado { get; set; }

        [JsonIgnore]
        public ICollection<ListaDesejo> ListaInteresse { get; set; }
        [JsonIgnore]
        public ICollection<ProdutoComentario> Comentarios { get; set; }
    }
}
