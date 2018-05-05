namespace Pessoa.Test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.Pessoa")]
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            ContatoEntidadeDeNegocio = new HashSet<ContatoEntidadeDeNegocio>();
            EnderecoEmail = new HashSet<EnderecoEmail>();
            TelefonePessoa = new HashSet<TelefonePessoa>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntidadeDeNegocioID { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoPessoa { get; set; }

        public bool EstiloNome { get; set; }

        [StringLength(8)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(50)]
        public string PrimeiroNome { get; set; }

        [StringLength(50)]
        public string NomeDoMeio { get; set; }

        [Required]
        [StringLength(50)]
        public string UltimoNome { get; set; }

        [StringLength(10)]
        public string Sufixo { get; set; }

        public int EmailPromocional { get; set; }

        [Column(TypeName = "xml")]
        public string InfoContatoAdicional { get; set; }

        [Column(TypeName = "xml")]
        public string Demografia { get; set; }

        public Guid rowguid { get; set; }

        public DateTime DataModificacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContatoEntidadeDeNegocio> ContatoEntidadeDeNegocio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnderecoEmail> EnderecoEmail { get; set; }

        public virtual EntidadeDeNegocio EntidadeDeNegocio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TelefonePessoa> TelefonePessoa { get; set; }

        public virtual Senha Senha { get; set; }
    }
}
