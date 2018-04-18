using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuloPessoa.Controllers;
using ModuloPessoa.Dao;
using ModuloSenha.Dao;

namespace ModuloPessoa.Tests
{
    [TestClass]
    public class TesteDaos
    {
        [TestInitialize]
        public void MainTest()
        {
            TipoEndereco tipoEndereco = new TipoEndereco();
            List<TipoEndereco> tipoEnderecos = new List<TipoEndereco>();
            TipoEnderecoDao enderecoDao = new TipoEnderecoDao();
            tipoEndereco.Nome = "Teste";
            tipoEndereco.rowguid = Guid.NewGuid();
            tipoEndereco.DataModificacao = DateTime.Now;
            bool funcionou = enderecoDao.Criar(tipoEndereco);
        }

        [TestMethod]
        public void CreateTipoEndereco()
        {
            TipoEndereco tipoEndereco = new TipoEndereco();          
            TipoEnderecoDao enderecoDao = new TipoEnderecoDao();
            tipoEndereco.Nome = "Teste";
            bool valido = enderecoDao.Criar(tipoEndereco);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreateContatoEntidadeDeNegocio()
        {
            ContatoEntidadeDeNegocio tipocontato = new ContatoEntidadeDeNegocio();             
            ContatoEntidadeDeNegocioDao contatoDao = new ContatoEntidadeDeNegocioDao();
            tipocontato.EntidadeDeNegocioID = 60;
            tipocontato.PessoaID = 100;
            bool valido = contatoDao.Criar(tipocontato);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreateEnderecoEmail()
        {
            EnderecoEmail enderecoEmail = new EnderecoEmail();           
            EnderecoEmailDao enderecoEmailDao = new EnderecoEmailDao();
            PessoaDao pessoaDao = new PessoaDao();
            enderecoEmail.EntidadeDeNegocioID = 60;
            enderecoEmail.EnderecoEmailID = 50;
            enderecoEmail.Pessoa = pessoaDao.Buscar(65);
            bool valido = enderecoEmailDao.Criar(enderecoEmail);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreateEnderecoEntidadeDeNegocio()
        {
            EnderecoEntidadeDeNegocio endereco = new EnderecoEntidadeDeNegocio();
            EnderecoEntidadeDeNegocioDao enderecoDao = new EnderecoEntidadeDeNegocioDao();
            PessoaDao pessoaDao = new PessoaDao();
            endereco.EntidadeNegocioID = 55;
            endereco.EnderecoID = 15;
            bool valido = enderecoDao.Criar(endereco);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreateEndereco()
        {
            Endereco endereco = new Endereco();
            EnderecoDao enderecoDao = new EnderecoDao();
            PessoaDao pessoaDao = new PessoaDao();
            endereco.Endereco1 = "Teste";
            endereco.Endereco2 = "Teste2";
            endereco.EnderecoID = 15;
            endereco.EstadoProvinciaID = 15;
            endereco.Cidade = "Toronto";
            endereco.CodigoPostal = "51515161";
            bool valido = enderecoDao.Criar(endereco);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreateEntidadeDeNegocio()
        {
            EntidadeDeNegocio en = new EntidadeDeNegocio();
            EntidadeDeNegocioDao end = new EntidadeDeNegocioDao();          
            
            bool valido = end.Criar(en);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreatePessoa()
        {
            Pessoa pe = new Pessoa();
            PessoaDao ped = new PessoaDao();
            EntidadeDeNegocioDao en = new EntidadeDeNegocioDao();
            Senha senha = new Senha();
            pe.EmailPromocional = 15;
            pe.EntidadeDeNegocio = en.Buscar(15);
            pe.EntidadeDeNegocioID = 15;
            pe.EstiloNome = true;
            pe.InfoContatoAdicional = "Diana";
            pe.NomeDoMeio = "Zabaré";
            pe.PrimeiroNome = "Jairo";
            pe.Sufixo = "BLA";
            pe.TipoPessoa = "F";
            pe.Titulo = "blalfef";
            pe.UltimoNome = "Gavilan";

            bool valido = ped.Criar(pe);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreateRegiao()
        {
            Regiao en = new Regiao();
            RegiaoDao end = new RegiaoDao();
            en.CodigoRegiao = "KXC";
            en.Nome = "KAKAKAAK";

            bool valido = end.Criar(en);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreateSenhas()
        {
            PessoaDao pe = new PessoaDao();
            Senha en = new Senha();
            SenhaDao end = new SenhaDao();
            en.EntidadeDeNegocioID = 50;
            en.Pessoa = pe.Buscar(18);
            en.SenhaHash = "blabla";
            en.SenhaSalt = "bibi";

            bool valido = end.Criar(en);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreateTelefonePessoas()
        {
            TelefonePessoa en = new TelefonePessoa();
            TelefonePessoaDao end = new TelefonePessoaDao();
            TipoNumeroTelefoneDao tdao = new TipoNumeroTelefoneDao();
            PessoaDao dao = new PessoaDao();
            en.EntidadeDeNegocioID = 29;
            en.NumeroTelefone = "33500101";
            en.Pessoa = dao.Buscar(20);
            en.TipoNumeroTelefone = tdao.Buscar(1);
            en.TipoNumeroTelefoneID = 1;

            bool valido = end.Criar(en);
            Assert.AreEqual(true, valido);
        }
        [TestMethod]
        public void CreateTipoContato()
        {
            TipoEndereco tipoEndereco = new TipoEndereco();
            List<TipoEndereco> tipoEnderecos = new List<TipoEndereco>();
            TipoEnderecoDao enderecoDao = new TipoEnderecoDao();
            tipoEndereco.Nome = "Teste";
            tipoEndereco.rowguid = Guid.NewGuid();
            tipoEndereco.DataModificacao = DateTime.Now;
            bool funcionou = enderecoDao.Criar(tipoEndereco);
        }
        [TestMethod]
        public void CreateTipoNumeroTelefone()
        {
            TipoNumeroTelefone tipo = new TipoNumeroTelefone();
            TipoNumeroTelefoneDao dao = new TipoNumeroTelefoneDao();
            tipo.TipoNumeroTelefoneID = 1;
            tipo.Nome = "Teste";
            bool funcionou = dao.Criar(tipo);
        }

        [TestMethod]
        public void List()
        {
            TipoEndereco tipoEndereco = new TipoEndereco();
            List<TipoEndereco> tipoEnderecos = new List<TipoEndereco>();
            TipoEnderecoDao enderecoDao = new TipoEnderecoDao();
            tipoEndereco.Nome = "Teste";
            tipoEndereco.rowguid = Guid.NewGuid();
            tipoEndereco.DataModificacao = DateTime.Now;
            bool funcionou = enderecoDao.Criar(tipoEndereco);
        }

    }
}
