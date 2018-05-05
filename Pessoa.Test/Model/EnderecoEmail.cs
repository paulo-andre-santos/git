namespace Pessoa.Test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.EnderecoEmail")]
    public partial class EnderecoEmail
    {
        [Required]
        public int EntidadeDeNegocioID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int EnderecoEmailID { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public Guid rowguid { get; set; }

        public DateTime DataModificacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
