namespace PrestadorServ.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_tipo_serv
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_tipo_serv { get; set; }

        [Required]
        [StringLength(32)]
        public string nome_tipo_serv { get; set; }

        public virtual tbl_tipo_serv tbl_tipo_serv1 { get; set; }

        public virtual tbl_tipo_serv tbl_tipo_serv2 { get; set; }
    }
}
