namespace PrestadorServ.Models.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tbl_prestado", Schema = "dbo")]
    public class ServicoPrestado
    {
        [Key]
        [Column("id_prestado")]
        public int IdServicoPrestado { get; set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Column("id_fornecedor")]
        public int IdFornecedor { get; set; }

        [Column("id_tipo_serv")]
        public int IdTipoServico { get; set; }

        [Column("desc_prestado", TypeName = "text")]
        public string DescricaoServicoPrestado { get; set; }

        [Column("dt_atend_prestado")]
        public DateTime DataAtendimentoServicoPrestado { get; set; }

        [Column("valor_prestado", TypeName = "money")]
        public decimal ValorServicoPrestado { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public virtual TipoServico TipoServico { get; set; }
    }
}
