namespace Pessoa.Test.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.Endereco")]
    public partial class Endereco
    {
        public int EnderecoID { get; set; }

        [Required]
        [StringLength(60)]
        public string Endereco1 { get; set; }

        [StringLength(60)]
        public string Endereco2 { get; set; }

        [Required]
        [StringLength(30)]
        public string Cidade { get; set; }

        public int EstadoProvinciaID { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoPostal { get; set; }

        //public DbGeography LocalEspacial { get; set; }

        public Guid rowguid { get; set; }

        public DateTime DataModificacao { get; set; }

        public virtual EstadoProvincia EstadoProvincia { get; set; }
    }
}
