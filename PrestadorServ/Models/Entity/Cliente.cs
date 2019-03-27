namespace PrestadorServ.Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tbl_cliente", Schema = "dbo")]
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Required]
        [Column("nome_cliente")]
        [StringLength(64)]
        public string NomeCliente { get; set; }

        [Required]
        [Column("bairro_cliente")]
        [StringLength(64)]
        public string BairroCliente { get; set; }

        [Required]
        [Column("cidade_cliente")]
        [StringLength(64)]
        public string CidadeCliente { get; set; }

        [Required]
        [Column("uf_cliente")]
        [StringLength(2)]
        public string UfCliente { get; set; }
    }
}
