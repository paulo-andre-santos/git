namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.ContatoEntidadeDeNegocio")]
    public partial class ContatoEntidadeDeNegocio
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntidadeDeNegocioID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PessoaID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoContatoID { get; set; }

        public Guid rowguid { get; set; }

        public DateTime DataModificacao { get; set; }

        public virtual EntidadeDeNegocio EntidadeDeNegocio { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual TipoContato TipoContato { get; set; }

        public ContatoEntidadeDeNegocio() {

        }

        public ContatoEntidadeDeNegocio(int entidadeDeNegocioID, int pessoaID, int tipoContatoID, Guid rowguid, DateTime dataModificacao, EntidadeDeNegocio entidadeDeNegocio, Pessoa pessoa, TipoContato tipoContato)
        {
            EntidadeDeNegocioID = entidadeDeNegocioID;
            PessoaID = pessoaID;
            TipoContatoID = tipoContatoID;
            this.rowguid = rowguid;
            DataModificacao = dataModificacao;
            EntidadeDeNegocio = entidadeDeNegocio;
            Pessoa = pessoa;
            TipoContato = tipoContato;
        }
    }
}
