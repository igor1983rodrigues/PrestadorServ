namespace PrestadorServ.Models.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tbl_fornecedor", Schema = "dbo")]
    public class Fornecedor
    {
        [Key]
        [Column("id_fornecedor")]
        public int IdFornecedor { get; set; }

        [Required]
        [Column("nome_fornecedor")]
        [StringLength(64)]
        public string NomeFornecedor { get; set; }
    }
}
