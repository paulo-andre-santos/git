namespace ModuloPessoa
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

        [Display(Name = "Entidade de Negócio ID")]
        public int EntidadeDeNegocioID { get; set; }

        [ScaffoldColumn(false)]
        public Guid rowguid { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContatoEntidadeDeNegocio> ContatoEntidadeDeNegocio { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public EntidadeDeNegocio(int entidadeDeNegocioID, Guid rowguid, DateTime dataModificacao, ICollection<ContatoEntidadeDeNegocio> contatoEntidadeDeNegocio, Pessoa pessoa)
        {
            EntidadeDeNegocioID = entidadeDeNegocioID;
            this.rowguid = rowguid;
            DataModificacao = dataModificacao;
            ContatoEntidadeDeNegocio = contatoEntidadeDeNegocio;
            Pessoa = pessoa;
        }
    }
}
