namespace ModuloPessoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa.Pessoa")]
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            ContatoEntidadeDeNegocio = new HashSet<ContatoEntidadeDeNegocio>();
            EnderecoEmail = new HashSet<EnderecoEmail>();
            TelefonePessoa = new HashSet<TelefonePessoa>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntidadeDeNegocioID { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Tipo de Pessoa")]
        public string TipoPessoa { get; set; }

        [Display(Name = "Estilo de Nome")]
        public bool EstiloNome { get; set; }

        [StringLength(8)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Primeiro Nome")]
        public string PrimeiroNome { get; set; }

        [StringLength(50)]
        [Display(Name = "Nome do Meio")]
        public string NomeDoMeio { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Último Nome")]
        public string UltimoNome { get; set; }

        [StringLength(10)]
        public string Sufixo { get; set; }

        [Display(Name = "Email Promocional")]
        public int EmailPromocional { get; set; }

        [Column(TypeName = "xml")]
        public string InfoContatoAdicional { get; set; }

        [Column(TypeName = "xml")]
        public string Demografia { get; set; }

        [ScaffoldColumn(false)]
        public Guid rowguid { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Contatos da Entidade de Negócio")]
        public virtual ICollection<ContatoEntidadeDeNegocio> ContatoEntidadeDeNegocio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Endereço de Email")]
        public virtual ICollection<EnderecoEmail> EnderecoEmail { get; set; }

        [Display(Name = "Entidade de Negócio")]
        public virtual EntidadeDeNegocio EntidadeDeNegocio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Lista de Telefone de Pessoas")]
        public virtual ICollection<TelefonePessoa> TelefonePessoa { get; set; }

        public virtual Senha Senha { get; set; }

        public Pessoa(int entidadeDeNegocioID, string tipoPessoa, bool estiloNome, string titulo, string primeiroNome, string nomeDoMeio, string ultimoNome, string sufixo, int emailPromocional, string infoContatoAdicional, string demografia, Guid rowguid, DateTime dataModificacao, ICollection<ContatoEntidadeDeNegocio> contatoEntidadeDeNegocio, ICollection<EnderecoEmail> enderecoEmail, EntidadeDeNegocio entidadeDeNegocio, ICollection<TelefonePessoa> telefonePessoa, Senha senha)
        {
            EntidadeDeNegocioID = entidadeDeNegocioID;
            TipoPessoa = tipoPessoa;
            EstiloNome = estiloNome;
            Titulo = titulo;
            PrimeiroNome = primeiroNome;
            NomeDoMeio = nomeDoMeio;
            UltimoNome = ultimoNome;
            Sufixo = sufixo;
            EmailPromocional = emailPromocional;
            InfoContatoAdicional = infoContatoAdicional;
            Demografia = demografia;
            this.rowguid = rowguid;
            DataModificacao = dataModificacao;
            ContatoEntidadeDeNegocio = contatoEntidadeDeNegocio;
            EnderecoEmail = enderecoEmail;
            EntidadeDeNegocio = entidadeDeNegocio;
            TelefonePessoa = telefonePessoa;
            Senha = senha;
        }
    }
}
