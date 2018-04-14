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
        public int EntidadeDeNegocioID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string NumeroTelefone { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoNumeroTelefoneID { get; set; }

        public DateTime DataModificacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }

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
