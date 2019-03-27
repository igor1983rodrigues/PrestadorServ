namespace PrestadorServ.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_usuario", Schema = "dbo")]
    public class Usuario
    {
        [Key]
        [Column("id_fornecedor")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFornecedor { get; set; }

        [Required]
        [Column("login_usuario")]
        [StringLength(32)]
        public string LoginUsuario { get; set; }

        [Required]
        [Column("senha_usuario")]
        [StringLength(64)]
        public string SenhaUsuario { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
    }
}
