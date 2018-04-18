using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class PessoaDao : ICRUD<Pessoa, int>
    {
        private PessoaConnection db = new PessoaConnection();

        public List<Pessoa> Listar => db.Pessoa.Include("EntidadeDeNegocio").Include("Senha").ToList();

        public Pessoa Buscar(int id) => db.Pessoa.Find(id);

        public bool Criar(Pessoa obj)
        {
            try
            {
                obj.rowguid = Guid.NewGuid();
                obj.DataModificacao = DateTime.Now;
                db.Pessoa.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool Deletar(Pessoa obj)
        {
            try
            {
                db.Pessoa.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Pessoa obj)
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