namespace Pessoa.Test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.EntidadeDeNegocio")]
    public partial class EntidadeDeNegocio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntidadeDeNegocio()
        {
            ContatoEntidadeDeNegocio = new HashSet<ContatoEntidadeDeNegocio>();
        }

        public int EntidadeDeNegocioID { get; set; }

        public Guid rowguid { get; set; }

        public DateTime DataModificacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContatoEntidadeDeNegocio> ContatoEntidadeDeNegocio { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
