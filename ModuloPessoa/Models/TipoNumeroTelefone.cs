namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.TipoNumeroTelefone")]
    public partial class TipoNumeroTelefone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoNumeroTelefone()
        {
            TelefonePessoa = new HashSet<TelefonePessoa>();
        }

        [Display(Name = "Tipo Número do Telefone")]
        public int TipoNumeroTelefoneID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TelefonePessoa> TelefonePessoa { get; set; }

        public TipoNumeroTelefone(int tipoNumeroTelefoneID, string nome, DateTime dataModificacao, ICollection<TelefonePessoa> telefonePessoa)
        {
            TipoNumeroTelefoneID = tipoNumeroTelefoneID;
            Nome = nome;
            DataModificacao = dataModificacao;
            TelefonePessoa = telefonePessoa;
        }
    }
}
