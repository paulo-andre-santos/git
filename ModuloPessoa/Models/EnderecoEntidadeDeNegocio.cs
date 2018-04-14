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
        public int EnderecoID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoEnderecoID { get; set; }

        public Guid rowguid { get; set; }

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
