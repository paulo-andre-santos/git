namespace ModuloPessoa
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
        [Display(Name = "Primeiro Endereço")]
        public string Endereco1 { get; set; }

        [StringLength(60)]
        [Display(Name = "Segundo Endereço")]
        public string Endereco2 { get; set; }

        [Required]
        [StringLength(30)]
        public string Cidade { get; set; }

        [Display(Name = "Província ID")]
        public int EstadoProvinciaID { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Display(Name = "Local Geográfico")]
        public DbGeography LocalEspacial { get; set; }

        [ScaffoldColumn(false)]
        public Guid rowguid { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        [Display(Name = "Província")]
        public virtual EstadoProvincia EstadoProvincia { get; set; }

        public Endereco() {

        }

        public Endereco(int enderecoID, string endereco1, string endereco2, string cidade, int estadoProvinciaID, string codigoPostal, DbGeography localEspacial, Guid rowguid, DateTime dataModificacao, EstadoProvincia estadoProvincia)
        {
            EnderecoID = enderecoID;
            Endereco1 = endereco1;
            Endereco2 = endereco2;
            Cidade = cidade;
            EstadoProvinciaID = estadoProvinciaID;
            CodigoPostal = codigoPostal;
            LocalEspacial = localEspacial;
            this.rowguid = rowguid;
            DataModificacao = dataModificacao;
            EstadoProvincia = estadoProvincia;
        }
    }
}
