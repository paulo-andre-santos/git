namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.EstadoProvincia")]
    public partial class EstadoProvincia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadoProvincia()
        {
            Endereco = new HashSet<Endereco>();
        }

        public int EstadoProvinciaID { get; set; }

        [Required]
        [StringLength(3)]
        public string CodigoEstadoProvincia { get; set; }

        [Required]
        [StringLength(3)]
        public string CodigoRegiao { get; set; }

        public bool SomenteEstadoProvinciaFlag { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public Guid rowguid { get; set; }

        public DateTime DataModificacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endereco> Endereco { get; set; }

        public virtual Regiao Regiao { get; set; }

        public EstadoProvincia(int estadoProvinciaID, string codigoEstadoProvincia, string codigoRegiao, bool somenteEstadoProvinciaFlag, string nome, Guid rowguid, DateTime dataModificacao, ICollection<Endereco> endereco, Regiao regiao)
        {
            EstadoProvinciaID = estadoProvinciaID;
            CodigoEstadoProvincia = codigoEstadoProvincia;
            CodigoRegiao = codigoRegiao;
            SomenteEstadoProvinciaFlag = somenteEstadoProvinciaFlag;
            Nome = nome;
            this.rowguid = rowguid;
            DataModificacao = dataModificacao;
            Endereco = endereco;
            Regiao = regiao;
        }
    }
}
