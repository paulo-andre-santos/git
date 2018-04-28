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
        [Display(Name = "Entidade de Neg�cio")]
        public int EntidadeDeNegocioID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Id Endere�o de Email")]
        public int EnderecoEmailID { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

       [ScaffoldColumn(false)]
        public Guid rowguid { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        [Display(Name = "Identifica��o de Pessoa")]
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
