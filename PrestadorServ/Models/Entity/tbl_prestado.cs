namespace PrestadorServ.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_prestado
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_cliente { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_fornecedor { get; set; }

        public int id_tipo_serv { get; set; }

        [Column(TypeName = "text")]
        public string desc_prestado { get; set; }

        public DateTime dt_atend_prestado { get; set; }

        [Column(TypeName = "money")]
        public decimal valor_prestado { get; set; }

        public virtual tbl_cliente tbl_cliente { get; set; }

        public virtual tbl_fornecedor tbl_fornecedor { get; set; }
    }
}
