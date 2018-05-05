using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoa.Test.Model;
using System.Data.Entity;
using System.Linq;
using System.Data.Spatial;

namespace Pessoa.Test
{
    [TestClass]
    public class UnitTest1
    {
        private PessoaConnection db = new PessoaConnection();
        Guid guid;
        Guid guid2;
        Guid guid3;
        string nTelefone;
        [TestMethod]
        public void Regiao()
        {
            bool passouPorTodos = true;
            //Criar
            try
            {
                Regiao obj = new Regiao();
                obj.CodigoRegiao = "AAB";
                obj.Nome = "Testeabab";
                obj.DataModificacao = DateTime.Now;
                db.Regiao.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                Regiao obj = new Regiao();
                obj = db.Regiao.FirstOrDefault(x => x.CodigoRegiao == "AAB");
                obj.Nome = "efefefef";
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<Regiao> Listar = db.Regiao.ToList();
            //Excluir
            try
            {
                Regiao obj = new Regiao();
                obj = db.Regiao.FirstOrDefault(x => x.CodigoRegiao == "AAB");
                db.Regiao.Remove(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //1
        [TestMethod]
        public void TipoEndereco()
        {
            bool passouPorTodos = true;
            //Criar
            try
            {
                TipoEndereco obj = new TipoEndereco();
                obj.Nome = "Testeabab";
                obj.DataModificacao = DateTime.Now;
                db.TipoEndereco.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                TipoEndereco obj = new TipoEndereco();
                obj = db.TipoEndereco.FirstOrDefault(x => x.Nome == "Testeabab");
                obj.Nome = "efefefef";
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<TipoEndereco> Listar = db.TipoEndereco.ToList();
            //Excluir
            try
            {
                TipoEndereco obj = new TipoEndereco();
                obj = db.TipoEndereco.FirstOrDefault(x => x.Nome == "efefefef");
                db.TipoEndereco.Remove(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //2
        [TestMethod]
        public void TipoContato()
        {
            bool passouPorTodos = true;
            //Criar
            try
            {
                TipoContato obj = new TipoContato();
                obj.Nome = "Testeabab";
                obj.DataModificacao = DateTime.Now;
                db.TipoContato.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                TipoContato obj = new TipoContato();
                obj = db.TipoContato.FirstOrDefault(x => x.Nome == "Testeabab");
                obj.Nome = "efefefef";
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<TipoContato> Listar = db.TipoContato.ToList();
            //Excluir
            try
            {
                TipoContato obj = new TipoContato();
                obj = db.TipoContato.FirstOrDefault(x => x.Nome == "efefefef");
                db.TipoContato.Remove(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //3
        [TestMethod]
        public void TipoNumeroTelefone()
        {
            bool passouPorTodos = true;
            //Criar
            try
            {
                TipoNumeroTelefone obj = new TipoNumeroTelefone();
                obj.Nome = "Testeabab";
                obj.DataModificacao = DateTime.Now;
                db.TipoNumeroTelefone.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                TipoNumeroTelefone obj = new TipoNumeroTelefone();
                obj = db.TipoNumeroTelefone.FirstOrDefault(x => x.Nome == "Testeabab");
                obj.Nome = "efefefef";
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<TipoNumeroTelefone> Listar = db.TipoNumeroTelefone.ToList();
            //Excluir
            try
            {
                TipoNumeroTelefone obj = new TipoNumeroTelefone();
                obj = db.TipoNumeroTelefone.FirstOrDefault(x => x.Nome == "efefefef");
                db.TipoNumeroTelefone.Remove(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //4
        [TestMethod]
        public void EstadoProvincia()
        {
            bool passouPorTodos = true;
            //Criar
            try
            {
                EstadoProvincia obj = new EstadoProvincia();
                obj.CodigoRegiao = "AD";
                obj.CodigoEstadoProvincia = "ZZ";
                obj.SomenteEstadoProvinciaFlag = true;
                obj.Nome = "NheeTeste";
                obj.rowguid = Guid.NewGuid();
                guid = obj.rowguid;
                obj.DataModificacao = DateTime.Now;
                db.EstadoProvincia.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                EstadoProvincia obj = new EstadoProvincia();
                obj = db.EstadoProvincia.FirstOrDefault(x => x.rowguid == guid);
                obj.Nome = "NovoNomeRecebidoTeste";
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<EstadoProvincia> listar = db.EstadoProvincia.ToList();
            if (listar == null || listar.Count == 0)
                passouPorTodos = false;
            //excluir
            try
            {
                EstadoProvincia obj = new EstadoProvincia();
                obj = db.EstadoProvincia.FirstOrDefault(x => x.rowguid == guid);
                db.EstadoProvincia.Remove(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //5
        [TestMethod]
        public void EnderecoEmail()
        {
            bool passouPorTodos = true;
            //Criar
            try
            {
                EnderecoEmail obj = new EnderecoEmail();
                obj.EntidadeDeNegocioID = 40;
                obj.Email = "ericksson0@adventure-works.com";
                obj.rowguid = Guid.NewGuid();
                guid = obj.rowguid;
                obj.DataModificacao = DateTime.Now;
                db.EnderecoEmail.Add(obj);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                EnderecoEmail obj = new EnderecoEmail();
                obj = db.EnderecoEmail.FirstOrDefault(x => x.rowguid == guid);
                obj.Email = "erickzzz0@adventure-works.com";
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<EnderecoEmail> listar = db.EnderecoEmail.ToList();
            if (listar == null || listar.Count == 0)
                passouPorTodos = false;
            //excluir
            try
            {
                EnderecoEmail obj = new EnderecoEmail();
                obj = db.EnderecoEmail.FirstOrDefault(x => x.rowguid == guid);
                db.EnderecoEmail.Remove(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //6
        [TestMethod]
        public void Endereco()
        {
            bool passouPorTodos = true;
            //Criar
            try
            {
                Endereco obj = new Endereco();
                obj.Endereco1 = "endereco1";
                obj.Endereco2 = "endereco2";
                obj.Cidade = "sistemasCorporation";
                obj.EstadoProvinciaID = 10;
                obj.CodigoPostal = "teste teste";
                obj.rowguid = Guid.NewGuid();
                guid = obj.rowguid;       
                obj.DataModificacao = DateTime.Now;
                db.Endereco.Add(obj);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                Endereco obj = new Endereco();
                obj = db.Endereco.FirstOrDefault(x => x.rowguid == guid);
                obj.Endereco1 = "fegegerh";
                obj.Endereco2 = "yjky5j5yj5yj5y";
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<Endereco> listar = db.Endereco.ToList();
            if (listar == null || listar.Count == 0)
                passouPorTodos = false;
            //excluir
            try
            {
                Endereco obj = new Endereco();
                obj = db.Endereco.FirstOrDefault(x => x.rowguid == guid);
                db.Endereco.Remove(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //7
        [TestMethod]
        public void ContatoEntidadeDeNegocio()
        {
            bool passouPorTodos = true;
            //Criar
            try
            {
                 ContatoEntidadeDeNegocio obj = new ContatoEntidadeDeNegocio();
                 obj.EntidadeDeNegocioID = 90;
                 obj.PessoaID = 50;
                 obj.TipoContatoID = 1;
                 obj.rowguid = Guid.NewGuid();
                 guid = obj.rowguid;
                 obj.DataModificacao = DateTime.Now;
                 db.ContatoEntidadeDeNegocio.Add(obj);
                 db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                ContatoEntidadeDeNegocio objr = new ContatoEntidadeDeNegocio();
                objr = db.ContatoEntidadeDeNegocio.FirstOrDefault(x => x.rowguid == guid);
                objr.DataModificacao = DateTime.Now;
                db.Entry(objr).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch 
            {
                passouPorTodos = false;
            }
            //Listar
            List<ContatoEntidadeDeNegocio> listar = db.ContatoEntidadeDeNegocio.ToList();
            if (listar == null || listar.Count == 0)
                passouPorTodos = false;
            //excluir
            try
            {
                ContatoEntidadeDeNegocio objr = new ContatoEntidadeDeNegocio();
                objr = db.ContatoEntidadeDeNegocio.FirstOrDefault(x => x.rowguid == guid);
                db.ContatoEntidadeDeNegocio.Remove(objr);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        }  //8
        [TestMethod]
        public void EnderecoEntidadeDeNegocio()
        {

            bool passouPorTodos = true;
            //Criar
            try
            {
                EnderecoEntidadeDeNegocio obj = new EnderecoEntidadeDeNegocio();
                obj.EntidadeNegocioID = 90;
                obj.EnderecoID = 5;
                obj.TipoEnderecoID = 1;
                obj.rowguid = Guid.NewGuid();
                guid = obj.rowguid;
                obj.DataModificacao = DateTime.Now;
                db.EnderecoEntidadeDeNegocio.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                EnderecoEntidadeDeNegocio objr = new EnderecoEntidadeDeNegocio();
                objr = db.EnderecoEntidadeDeNegocio.FirstOrDefault(x => x.rowguid == guid);
                objr.DataModificacao = DateTime.Now;
                db.Entry(objr).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<EnderecoEntidadeDeNegocio> listar = db.EnderecoEntidadeDeNegocio.ToList();
            if (listar == null || listar.Count == 0)
                passouPorTodos = false;
            //excluir
            try
            {
                EnderecoEntidadeDeNegocio objr = new EnderecoEntidadeDeNegocio();
                objr = db.EnderecoEntidadeDeNegocio.FirstOrDefault(x => x.rowguid == guid);
                db.EnderecoEntidadeDeNegocio.Remove(objr);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        }  //9
        [TestMethod]
        public void EntidadeDeNegocio()
        {
            bool passouPorTodos = true;
            //Criar
            try
            {
                EntidadeDeNegocio obj = new EntidadeDeNegocio();
                obj.DataModificacao = DateTime.Now;
                obj.rowguid = Guid.NewGuid();
                guid = obj.rowguid;
                db.EntidadeDeNegocio.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                EntidadeDeNegocio obj = new EntidadeDeNegocio();
                obj = db.EntidadeDeNegocio.FirstOrDefault(x => x.rowguid == guid);    
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<EntidadeDeNegocio> listar = db.EntidadeDeNegocio.ToList();
            if (listar == null || listar.Count == 0)
                passouPorTodos = false;
            //excluir
            try
            {
                EntidadeDeNegocio obj = new EntidadeDeNegocio();
                obj = db.EntidadeDeNegocio.FirstOrDefault(x => x.rowguid == guid);
                db.EntidadeDeNegocio.Remove(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //10
        [TestMethod]
        public void Pessoa()
        {
            bool passouPorTodos = true;
            //Criar
            EntidadeDeNegocio obj0 = new EntidadeDeNegocio();
            obj0.DataModificacao = DateTime.Now;
            obj0.rowguid = Guid.NewGuid();
            guid2 = obj0.rowguid;
            db.EntidadeDeNegocio.Add(obj0);
            db.SaveChanges();

            try
            {
                Test.Model.Pessoa obj = new Test.Model.Pessoa();
                obj.EntidadeDeNegocioID = obj0.EntidadeDeNegocioID;
                obj.TipoPessoa = "TS";
                obj.EstiloNome = true;
                obj.Titulo = "Sr";
                obj.PrimeiroNome = "teste primeiro";
                obj.NomeDoMeio = "teste meio";
                obj.UltimoNome = "teste fim";
                obj.Sufixo = "Jr.";
                obj.EmailPromocional = 0;
                obj.rowguid = Guid.NewGuid();
                guid = obj.rowguid;
                obj.DataModificacao = DateTime.Now;
                db.Pessoa.Add(obj);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                Test.Model.Pessoa obj = new Test.Model.Pessoa();
                obj = db.Pessoa.FirstOrDefault(x => x.rowguid == guid);
                obj.PrimeiroNome = "testefef primeiro";
                obj.NomeDoMeio = "teggergeste meio";
                obj.UltimoNome = "teegergeste fim";
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<Test.Model.Pessoa> listar = db.Pessoa.ToList();
            if (listar == null || listar.Count == 0)
                passouPorTodos = false;
            //excluir
            try
            {
                Test.Model.Pessoa obj = new Test.Model.Pessoa();
                obj = db.Pessoa.FirstOrDefault(x => x.rowguid == guid);
                db.Pessoa.Remove(obj);
                db.SaveChanges();

                EntidadeDeNegocio obj1 = new EntidadeDeNegocio();
                obj1 = db.EntidadeDeNegocio.FirstOrDefault(x => x.rowguid == guid2);
                db.EntidadeDeNegocio.Remove(obj1);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //11
        [TestMethod]
        public void Senha()
        {
            bool passouPorTodos = true;
            //Criar
            #region criarEntidade
            EntidadeDeNegocio obj0 = new EntidadeDeNegocio();
            obj0.DataModificacao = DateTime.Now;
            obj0.rowguid = Guid.NewGuid();
            guid2 = obj0.rowguid;
            db.EntidadeDeNegocio.Add(obj0);
            db.SaveChanges();
            #endregion criarEntidade

            #region criarPessoa
            Test.Model.Pessoa obj3 = new Test.Model.Pessoa();
            obj3.EntidadeDeNegocioID = obj0.EntidadeDeNegocioID;
            obj3.TipoPessoa = "TS";
            obj3.EstiloNome = true;
            obj3.Titulo = "Sr";
            obj3.PrimeiroNome = "teste primeiro";
            obj3.NomeDoMeio = "teste meio";
            obj3.UltimoNome = "teste fim";
            obj3.Sufixo = "Jr.";
            obj3.EmailPromocional = 0;
            obj3.rowguid = Guid.NewGuid();
            guid3 = obj3.rowguid;
            obj3.DataModificacao = DateTime.Now;
            db.Pessoa.Add(obj3);
            db.SaveChanges();
            #endregion criarPessoa

            try
            {
                Senha obj = new Senha();
                obj.EntidadeDeNegocioID = obj0.EntidadeDeNegocioID;
                obj.SenhaHash = "@1efefefefefe";
                obj.SenhaSalt = "@1rgrgrhcf";        
                obj.rowguid = Guid.NewGuid();
                guid = obj.rowguid;
                obj.DataModificacao = DateTime.Now;
                db.Senha.Add(obj);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                Senha obj = new Senha();
                obj = db.Senha.FirstOrDefault(x => x.rowguid == guid);
                obj.SenhaHash = "@gergergreh1";
                obj.SenhaSalt = "@1efefefe";
                obj.DataModificacao = DateTime.Now;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<Senha> listar = db.Senha.ToList();
            if (listar == null || listar.Count == 0)
                passouPorTodos = false;
            //excluir
            try
            {
                #region excluiEntidadeEPessoa
                Senha obj = new Senha();
                obj = db.Senha.FirstOrDefault(x => x.rowguid == guid);
                db.Senha.Remove(obj);
                db.SaveChanges();

                Test.Model.Pessoa obj2 = new Test.Model.Pessoa();
                obj2 = db.Pessoa.FirstOrDefault(x => x.rowguid == guid3);
                db.Pessoa.Remove(obj2);
                db.SaveChanges();
                #endregion excluiEntidadeEPessoa

                EntidadeDeNegocio obj1 = new EntidadeDeNegocio();
                obj1 = db.EntidadeDeNegocio.FirstOrDefault(x => x.rowguid == guid2);
                db.EntidadeDeNegocio.Remove(obj1);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        } //12
        [TestMethod]
        public void TelefonePessoa()
        {            
            bool passouPorTodos = true;
            //Criar
            try
            {
                TelefonePessoa obj = new TelefonePessoa();
                obj.EntidadeDeNegocioID = 90;
                obj.TipoNumeroTelefoneID = 3;
                obj.NumeroTelefone = "+55(41)99599-3244";
                nTelefone = obj.NumeroTelefone;
                obj.DataModificacao = DateTime.Now;
                db.TelefonePessoa.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Alterar
            try
            {
                TelefonePessoa objr = new TelefonePessoa();
                objr = db.TelefonePessoa.FirstOrDefault(x => x.NumeroTelefone == nTelefone);
                objr.DataModificacao = DateTime.Now;
                db.Entry(objr).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            //Listar
            List<TelefonePessoa> listar = db.TelefonePessoa.ToList();
            if (listar == null || listar.Count == 0)
                passouPorTodos = false;
            //excluir
            try
            {
                TelefonePessoa objr = new TelefonePessoa();
                objr = db.TelefonePessoa.FirstOrDefault(x => x.NumeroTelefone == nTelefone);
                db.TelefonePessoa.Remove(objr);
                db.SaveChanges();
            }
            catch
            {
                passouPorTodos = false;
            }
            Assert.AreEqual(true, passouPorTodos);
        }
    }
}
