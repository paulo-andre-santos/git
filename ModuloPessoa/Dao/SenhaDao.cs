using ModuloPessoa;
using ModuloPessoa.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloSenha.Dao
{
    public class SenhaDao : ICRUD<Senha, int>
    {
        private PessoaConnection db = new PessoaConnection();

        public List<Senha> Listar => db.Senha.Include("Pessoa").ToList();

        public Senha Buscar(int id) => db.Senha.Find(id);

        public bool Criar(Senha obj)
        {
            try
            {
                obj.rowguid = Guid.NewGuid();
                obj.DataModificacao = DateTime.Now;
                db.Senha.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool Deletar(Senha obj)
        {
            try
            {
                db.Senha.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Senha obj)
        {
            try
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}