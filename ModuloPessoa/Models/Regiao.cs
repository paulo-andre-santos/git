namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.Regiao")]
    public partial class Regiao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Regiao()
        {
            EstadoProvincia = new HashSet<EstadoProvincia>();
        }

        [Key]
        [StringLength(3)]
        [Display(Name = "Código da Região")]
        public string CodigoRegiao { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        [Display(Name = "Província")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstadoProvincia> EstadoProvincia { get; set; }

        public Regiao(string codigoRegiao, string nome, DateTime dataModificacao, ICollection<EstadoProvincia> estadoProvincia)
        {
            CodigoRegiao = codigoRegiao;
            Nome = nome;
            DataModificacao = dataModificacao;
            EstadoProvincia = estadoProvincia;
        }
    }
}
