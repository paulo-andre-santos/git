namespace Pessoa.Test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.TipoEndereco")]
    public partial class TipoEndereco
    {
        public int TipoEnderecoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public Guid rowguid { get; set; }

        public DateTime DataModificacao { get; set; }
    }
}
