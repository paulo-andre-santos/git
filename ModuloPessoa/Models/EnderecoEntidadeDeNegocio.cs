namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.EnderecoEntidadeDeNegocio")]
    public partial class EnderecoEntidadeDeNegocio
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntidadeNegocioID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Endereço ID")]
        public int EnderecoID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Tipo de Endereço ID")]
        public int TipoEnderecoID { get; set; }

        [ScaffoldColumn(false)]
        public Guid rowguid { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        public EnderecoEntidadeDeNegocio() {

        }

        public EnderecoEntidadeDeNegocio(int entidadeNegocioID, int enderecoID, int tipoEnderecoID, Guid rowguid, DateTime dataModificacao)
        {
            EntidadeNegocioID = entidadeNegocioID;
            EnderecoID = enderecoID;
            TipoEnderecoID = tipoEnderecoID;
            this.rowguid = rowguid;
            DataModificacao = dataModificacao;
        }
    }
}
