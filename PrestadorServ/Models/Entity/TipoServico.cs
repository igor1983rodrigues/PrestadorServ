namespace PrestadorServ.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_tipo_serv", Schema = "dbo")]
    public class TipoServico
    {
        [Key]
        [Column("id_tipo_serv")]
        public int IdTipoServico { get; set; }

        [Required]
        [Column("nome_tipo_serv")]
        [StringLength(32)]
        public string NomeTipoServico { get; set; }
    }
}
