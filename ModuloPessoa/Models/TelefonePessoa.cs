namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.TelefonePessoa")]
    public partial class TelefonePessoa
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Entidade de Negócio ID")]
        public int EntidadeDeNegocioID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        [Display(Name = "Número do Telefone")]
        public string NumeroTelefone { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Número do Telefone ID")]
        public int TipoNumeroTelefoneID { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        [Display(Name = "Número do Telefone")]
        public virtual TipoNumeroTelefone TipoNumeroTelefone { get; set; }

        public TelefonePessoa() {
        }

        public TelefonePessoa(int entidadeDeNegocioID, string numeroTelefone, int tipoNumeroTelefoneID, DateTime dataModificacao, Pessoa pessoa, TipoNumeroTelefone tipoNumeroTelefone)
        {
            EntidadeDeNegocioID = entidadeDeNegocioID;
            NumeroTelefone = numeroTelefone;
            TipoNumeroTelefoneID = tipoNumeroTelefoneID;
            DataModificacao = dataModificacao;
            Pessoa = pessoa;
            TipoNumeroTelefone = tipoNumeroTelefone;
        }
    }
}
