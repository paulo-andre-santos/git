namespace Pessoa.Test.Model
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
        public string SenhaHash { get; set; }

        [Required]
        [StringLength(10)]
        public string SenhaSalt { get; set; }

        public Guid rowguid { get; set; }

        public DateTime DataModificacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
