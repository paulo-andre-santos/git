namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.TipoContato")]
    public partial class TipoContato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoContato()
        {
            ContatoEntidadeDeNegocio = new HashSet<ContatoEntidadeDeNegocio>();
        }

        [Key]
        [Column("TipoContato")]
        public int TipoContato1 { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public DateTime DataModificacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContatoEntidadeDeNegocio> ContatoEntidadeDeNegocio { get; set; }

        public TipoContato(int tipoContato1, string nome, DateTime dataModificacao, ICollection<ContatoEntidadeDeNegocio> contatoEntidadeDeNegocio)
        {
            TipoContato1 = tipoContato1;
            Nome = nome;
            DataModificacao = dataModificacao;
            ContatoEntidadeDeNegocio = contatoEntidadeDeNegocio;
        }
    }
}
