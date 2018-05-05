namespace Pessoa.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Pessoa.ContatoEntidadeDeNegocio",
                c => new
                    {
                        EntidadeDeNegocioID = c.Int(nullable: false),
                        PessoaID = c.Int(nullable: false),
                        TipoContatoID = c.Int(nullable: false),
                        rowguid = c.Guid(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.EntidadeDeNegocioID, t.PessoaID, t.TipoContatoID })
                .ForeignKey("Pessoa.EntidadeDeNegocio", t => t.EntidadeDeNegocioID)
                .ForeignKey("Pessoa.Pessoa", t => t.PessoaID)
                .ForeignKey("Pessoa.TipoContato", t => t.TipoContatoID)
                .Index(t => t.EntidadeDeNegocioID)
                .Index(t => t.PessoaID)
                .Index(t => t.TipoContatoID);
            
            CreateTable(
                "Pessoa.EntidadeDeNegocio",
                c => new
                    {
                        EntidadeDeNegocioID = c.Int(nullable: false, identity: true),
                        rowguid = c.Guid(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntidadeDeNegocioID);
            
            CreateTable(
                "Pessoa.Pessoa",
                c => new
                    {
                        EntidadeDeNegocioID = c.Int(nullable: false),
                        TipoPessoa = c.String(nullable: false, maxLength: 2, fixedLength: true),
                        EstiloNome = c.Boolean(nullable: false),
                        Titulo = c.String(maxLength: 8),
                        PrimeiroNome = c.String(nullable: false, maxLength: 50),
                        NomeDoMeio = c.String(maxLength: 50),
                        UltimoNome = c.String(nullable: false, maxLength: 50),
                        Sufixo = c.String(maxLength: 10),
                        EmailPromocional = c.Int(nullable: false),
                        InfoContatoAdicional = c.String(storeType: "xml"),
                        Demografia = c.String(storeType: "xml"),
                        rowguid = c.Guid(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntidadeDeNegocioID)
                .ForeignKey("Pessoa.EntidadeDeNegocio", t => t.EntidadeDeNegocioID)
                .Index(t => t.EntidadeDeNegocioID);
            
            CreateTable(
                "Pessoa.EnderecoEmail",
                c => new
                    {
                        EnderecoEmailID = c.Int(nullable: false, identity: true),
                        EntidadeDeNegocioID = c.Int(nullable: false),
                        Email = c.String(maxLength: 50),
                        rowguid = c.Guid(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoEmailID)
                .ForeignKey("Pessoa.Pessoa", t => t.EntidadeDeNegocioID)
                .Index(t => t.EntidadeDeNegocioID);
            
            CreateTable(
                "Pessoa.Senha",
                c => new
                    {
                        EntidadeDeNegocioID = c.Int(nullable: false),
                        SenhaHash = c.String(nullable: false, maxLength: 128, unicode: false),
                        SenhaSalt = c.String(nullable: false, maxLength: 10, unicode: false),
                        rowguid = c.Guid(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntidadeDeNegocioID)
                .ForeignKey("Pessoa.Pessoa", t => t.EntidadeDeNegocioID)
                .Index(t => t.EntidadeDeNegocioID);
            
            CreateTable(
                "Pessoa.TelefonePessoa",
                c => new
                    {
                        EntidadeDeNegocioID = c.Int(nullable: false),
                        NumeroTelefone = c.String(nullable: false, maxLength: 25),
                        TipoNumeroTelefoneID = c.Int(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.EntidadeDeNegocioID, t.NumeroTelefone, t.TipoNumeroTelefoneID })
                .ForeignKey("Pessoa.TipoNumeroTelefone", t => t.TipoNumeroTelefoneID)
                .ForeignKey("Pessoa.Pessoa", t => t.EntidadeDeNegocioID)
                .Index(t => t.EntidadeDeNegocioID)
                .Index(t => t.TipoNumeroTelefoneID);
            
            CreateTable(
                "Pessoa.TipoNumeroTelefone",
                c => new
                    {
                        TipoNumeroTelefoneID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TipoNumeroTelefoneID);
            
            CreateTable(
                "Pessoa.TipoContato",
                c => new
                    {
                        TipoContato = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TipoContato);
            
            CreateTable(
                "Pessoa.Endereco",
                c => new
                    {
                        EnderecoID = c.Int(nullable: false, identity: true),
                        Endereco1 = c.String(nullable: false, maxLength: 60),
                        Endereco2 = c.String(maxLength: 60),
                        Cidade = c.String(nullable: false, maxLength: 30),
                        EstadoProvinciaID = c.Int(nullable: false),
                        CodigoPostal = c.String(nullable: false, maxLength: 15),
                        LocalEspacial = c.Geography(),
                        rowguid = c.Guid(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoID)
                .ForeignKey("Pessoa.EstadoProvincia", t => t.EstadoProvinciaID)
                .Index(t => t.EstadoProvinciaID);
            
            CreateTable(
                "Pessoa.EstadoProvincia",
                c => new
                    {
                        EstadoProvinciaID = c.Int(nullable: false, identity: true),
                        CodigoEstadoProvincia = c.String(nullable: false, maxLength: 3, fixedLength: true),
                        CodigoRegiao = c.String(nullable: false, maxLength: 3),
                        SomenteEstadoProvinciaFlag = c.Boolean(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                        rowguid = c.Guid(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoProvinciaID)
                .ForeignKey("Pessoa.Regiao", t => t.CodigoRegiao)
                .Index(t => t.CodigoRegiao);
            
            CreateTable(
                "Pessoa.Regiao",
                c => new
                    {
                        CodigoRegiao = c.String(nullable: false, maxLength: 3),
                        Nome = c.String(nullable: false, maxLength: 50),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoRegiao);
            
            CreateTable(
                "Pessoa.EnderecoEntidadeDeNegocio",
                c => new
                    {
                        EntidadeNegocioID = c.Int(nullable: false),
                        EnderecoID = c.Int(nullable: false),
                        TipoEnderecoID = c.Int(nullable: false),
                        rowguid = c.Guid(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.EntidadeNegocioID, t.EnderecoID, t.TipoEnderecoID });
            
            CreateTable(
                "Pessoa.TipoEndereco",
                c => new
                    {
                        TipoEnderecoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        rowguid = c.Guid(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TipoEnderecoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Pessoa.EstadoProvincia", "CodigoRegiao", "Pessoa.Regiao");
            DropForeignKey("Pessoa.Endereco", "EstadoProvinciaID", "Pessoa.EstadoProvincia");
            DropForeignKey("Pessoa.ContatoEntidadeDeNegocio", "TipoContatoID", "Pessoa.TipoContato");
            DropForeignKey("Pessoa.Pessoa", "EntidadeDeNegocioID", "Pessoa.EntidadeDeNegocio");
            DropForeignKey("Pessoa.TelefonePessoa", "EntidadeDeNegocioID", "Pessoa.Pessoa");
            DropForeignKey("Pessoa.TelefonePessoa", "TipoNumeroTelefoneID", "Pessoa.TipoNumeroTelefone");
            DropForeignKey("Pessoa.Senha", "EntidadeDeNegocioID", "Pessoa.Pessoa");
            DropForeignKey("Pessoa.EnderecoEmail", "EntidadeDeNegocioID", "Pessoa.Pessoa");
            DropForeignKey("Pessoa.ContatoEntidadeDeNegocio", "PessoaID", "Pessoa.Pessoa");
            DropForeignKey("Pessoa.ContatoEntidadeDeNegocio", "EntidadeDeNegocioID", "Pessoa.EntidadeDeNegocio");
            DropIndex("Pessoa.EstadoProvincia", new[] { "CodigoRegiao" });
            DropIndex("Pessoa.Endereco", new[] { "EstadoProvinciaID" });
            DropIndex("Pessoa.TelefonePessoa", new[] { "TipoNumeroTelefoneID" });
            DropIndex("Pessoa.TelefonePessoa", new[] { "EntidadeDeNegocioID" });
            DropIndex("Pessoa.Senha", new[] { "EntidadeDeNegocioID" });
            DropIndex("Pessoa.EnderecoEmail", new[] { "EntidadeDeNegocioID" });
            DropIndex("Pessoa.Pessoa", new[] { "EntidadeDeNegocioID" });
            DropIndex("Pessoa.ContatoEntidadeDeNegocio", new[] { "TipoContatoID" });
            DropIndex("Pessoa.ContatoEntidadeDeNegocio", new[] { "PessoaID" });
            DropIndex("Pessoa.ContatoEntidadeDeNegocio", new[] { "EntidadeDeNegocioID" });
            DropTable("Pessoa.TipoEndereco");
            DropTable("Pessoa.EnderecoEntidadeDeNegocio");
            DropTable("Pessoa.Regiao");
            DropTable("Pessoa.EstadoProvincia");
            DropTable("Pessoa.Endereco");
            DropTable("Pessoa.TipoContato");
            DropTable("Pessoa.TipoNumeroTelefone");
            DropTable("Pessoa.TelefonePessoa");
            DropTable("Pessoa.Senha");
            DropTable("Pessoa.EnderecoEmail");
            DropTable("Pessoa.Pessoa");
            DropTable("Pessoa.EntidadeDeNegocio");
            DropTable("Pessoa.ContatoEntidadeDeNegocio");
        }
    }
}
