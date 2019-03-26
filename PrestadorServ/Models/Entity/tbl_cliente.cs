namespace PrestadorServ.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_cliente()
        {
            tbl_prestado = new HashSet<tbl_prestado>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_cliente { get; set; }

        [Required]
        [StringLength(64)]
        public string nome_cliente { get; set; }

        [Required]
        [StringLength(64)]
        public string bairro_cliente { get; set; }

        [Required]
        [StringLength(64)]
        public string cidade_cliente { get; set; }

        [Required]
        [StringLength(2)]
        public string cliente_uf { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_prestado> tbl_prestado { get; set; }
    }
}
