namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.EnderecoEmail")]
    public partial class EnderecoEmail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntidadeDeNegocioID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int EnderecoEmailID { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public Guid rowguid { get; set; }

        public DateTime DataModificacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public EnderecoEmail() {

        }

        public EnderecoEmail(int entidadeDeNegocioID, int enderecoEmailID, string email, Guid rowguid, DateTime dataModificacao, Pessoa pessoa)
        {
            EntidadeDeNegocioID = entidadeDeNegocioID;
            EnderecoEmailID = enderecoEmailID;
            Email = email;
            this.rowguid = rowguid;
            DataModificacao = dataModificacao;
            Pessoa = pessoa;
        }
    }
}
