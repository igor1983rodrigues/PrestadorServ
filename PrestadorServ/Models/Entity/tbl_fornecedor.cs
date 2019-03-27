namespace PrestadorServ.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_fornecedor()
        {
            tbl_prestado = new HashSet<ServicoPrestado>();
        }

        [Key]
        public int id_fornecedor { get; set; }

        [Required]
        [StringLength(64)]
        public string nome_fornecedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicoPrestado> tbl_prestado { get; set; }

        public virtual tbl_usuario tbl_usuario { get; set; }
    }
}
