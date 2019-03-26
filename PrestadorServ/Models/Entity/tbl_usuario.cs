namespace PrestadorServ.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_fornecedor { get; set; }

        [Required]
        [StringLength(32)]
        public string login_usuario { get; set; }

        [Required]
        [StringLength(64)]
        public string senha_usuario { get; set; }

        public virtual tbl_fornecedor tbl_fornecedor { get; set; }
    }
}
