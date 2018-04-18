using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class TipoNumeroTelefoneDao : ICRUD<TipoNumeroTelefone, int>
    {
        private PessoaConnection db = new PessoaConnection();

        public List<TipoNumeroTelefone> Listar => db.TipoNumeroTelefone.ToList();

        public TipoNumeroTelefone Buscar(int id) => db.TipoNumeroTelefone.Find(id);

        public bool Criar(TipoNumeroTelefone obj)
        {
            try
            {
                obj.DataModificacao = DateTime.Now;
                db.TipoNumeroTelefone.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool Deletar(TipoNumeroTelefone obj)
        {
            try
            {
                db.TipoNumeroTelefone.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(TipoNumeroTelefone obj)
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