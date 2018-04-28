namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.TipoEndereco")]
    public partial class TipoEndereco
    {
        [Display(Name = "Tipo do Endereço ID")]
        public int TipoEnderecoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public Guid rowguid { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        public TipoEndereco()
        {

        }

        public TipoEndereco(int tipoEnderecoID, string nome, Guid rowguid, DateTime dataModificacao)
        {
            TipoEnderecoID = tipoEnderecoID;
            Nome = nome;
            this.rowguid = rowguid;
            DataModificacao = dataModificacao;
        }

    }
}
