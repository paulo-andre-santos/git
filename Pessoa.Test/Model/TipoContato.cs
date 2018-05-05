namespace Pessoa.Test.Model
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
    }
}
