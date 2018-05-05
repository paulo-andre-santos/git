namespace Pessoa.Test.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PessoaConnection : DbContext
    {
        public PessoaConnection()
            : base("name=PessoaConnection")
        {
        }

        public virtual DbSet<ContatoEntidadeDeNegocio> ContatoEntidadeDeNegocio { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<EnderecoEmail> EnderecoEmail { get; set; }
        public virtual DbSet<EnderecoEntidadeDeNegocio> EnderecoEntidadeDeNegocio { get; set; }
        public virtual DbSet<EntidadeDeNegocio> EntidadeDeNegocio { get; set; }
        public virtual DbSet<EstadoProvincia> EstadoProvincia { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Regiao> Regiao { get; set; }
        public virtual DbSet<Senha> Senha { get; set; }
        public virtual DbSet<TelefonePessoa> TelefonePessoa { get; set; }
        public virtual DbSet<TipoContato> TipoContato { get; set; }
        public virtual DbSet<TipoEndereco> TipoEndereco { get; set; }
        public virtual DbSet<TipoNumeroTelefone> TipoNumeroTelefone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntidadeDeNegocio>()
                .HasMany(e => e.ContatoEntidadeDeNegocio)
                .WithRequired(e => e.EntidadeDeNegocio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EntidadeDeNegocio>()
                .HasOptional(e => e.Pessoa)
                .WithRequired(e => e.EntidadeDeNegocio);

            modelBuilder.Entity<EstadoProvincia>()
                .Property(e => e.CodigoEstadoProvincia)
                .IsFixedLength();

            modelBuilder.Entity<EstadoProvincia>()
                .HasMany(e => e.Endereco)
                .WithRequired(e => e.EstadoProvincia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.TipoPessoa)
                .IsFixedLength();

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.ContatoEntidadeDeNegocio)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.PessoaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.EnderecoEmail)
                .WithRequired(e => e.Pessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.TelefonePessoa)
                .WithRequired(e => e.Pessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasOptional(e => e.Senha)
                .WithRequired(e => e.Pessoa);

            modelBuilder.Entity<Regiao>()
                .HasMany(e => e.EstadoProvincia)
                .WithRequired(e => e.Regiao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Senha>()
                .Property(e => e.SenhaHash)
                .IsUnicode(false);

            modelBuilder.Entity<Senha>()
                .Property(e => e.SenhaSalt)
                .IsUnicode(false);

            modelBuilder.Entity<TipoContato>()
                .HasMany(e => e.ContatoEntidadeDeNegocio)
                .WithRequired(e => e.TipoContato)
                .HasForeignKey(e => e.TipoContatoID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoNumeroTelefone>()
                .HasMany(e => e.TelefonePessoa)
                .WithRequired(e => e.TipoNumeroTelefone)
                .WillCascadeOnDelete(false);
        }
    }
}
