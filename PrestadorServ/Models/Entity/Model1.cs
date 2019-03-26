namespace PrestadorServ.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbl_cliente> tbl_cliente { get; set; }
        public virtual DbSet<tbl_fornecedor> tbl_fornecedor { get; set; }
        public virtual DbSet<tbl_prestado> tbl_prestado { get; set; }
        public virtual DbSet<tbl_tipo_serv> tbl_tipo_serv { get; set; }
        public virtual DbSet<tbl_usuario> tbl_usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.nome_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.bairro_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.cidade_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .Property(e => e.cliente_uf)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_cliente>()
                .HasMany(e => e.tbl_prestado)
                .WithRequired(e => e.tbl_cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_fornecedor>()
                .Property(e => e.nome_fornecedor)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_fornecedor>()
                .HasMany(e => e.tbl_prestado)
                .WithRequired(e => e.tbl_fornecedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_fornecedor>()
                .HasOptional(e => e.tbl_usuario)
                .WithRequired(e => e.tbl_fornecedor)
                .WillCascadeOnDelete();

            modelBuilder.Entity<tbl_prestado>()
                .Property(e => e.desc_prestado)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_prestado>()
                .Property(e => e.valor_prestado)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_tipo_serv>()
                .Property(e => e.nome_tipo_serv)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_tipo_serv>()
                .HasOptional(e => e.tbl_tipo_serv1)
                .WithRequired(e => e.tbl_tipo_serv2);

            modelBuilder.Entity<tbl_usuario>()
                .Property(e => e.login_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_usuario>()
                .Property(e => e.senha_usuario)
                .IsUnicode(false);
        }
    }
}
