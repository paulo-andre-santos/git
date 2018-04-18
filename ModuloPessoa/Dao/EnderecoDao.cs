using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class EnderecoDao : ICRUD<Endereco, int>
    {
        private PessoaConnection db = Singleton.Instance.Context;

        public Endereco Buscar(int id) => db.Endereco.Find(id);

        public bool Criar(Endereco obj)
        {
            try
            {
                obj.rowguid = Guid.NewGuid();
                obj.DataModificacao = DateTime.Now;
                db.Endereco.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(Endereco obj)
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

        public bool Deletar(Endereco obj)
        {
            try
            {
                db.Endereco.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Endereco> Listar => db.Endereco.Include("EstadoProvincia").ToList();
    }
}