namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.Senha")]
    public partial class Senha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntidadeDeNegocioID { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Senha Hash")]
        public string SenhaHash { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Senha Salt")]
        public string SenhaSalt { get; set; }

        [ScaffoldColumn(false)]
        public Guid rowguid { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public Senha() {
        }

        public Senha(int entidadeDeNegocioID, string senhaHash, string senhaSalt, Guid rowguid, DateTime dataModificacao, Pessoa pessoa)
        {
            EntidadeDeNegocioID = entidadeDeNegocioID;
            SenhaHash = senhaHash;
            SenhaSalt = senhaSalt;
            this.rowguid = rowguid;
            DataModificacao = dataModificacao;
            Pessoa = pessoa;
        }
    }
}
