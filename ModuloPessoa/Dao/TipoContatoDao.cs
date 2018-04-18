using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class TipoContatoDao : ICRUD<TipoContato, int>
    {
        private PessoaConnection db = new PessoaConnection();

        public List<TipoContato> Listar => db.TipoContato.ToList();

        public TipoContato Buscar(int id) => db.TipoContato.Find(id);

        public bool Criar(TipoContato obj)
        {
            try
            {
                obj.DataModificacao = DateTime.Now;
                db.TipoContato.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool Deletar(TipoContato obj)
        {
            try
            {
                db.TipoContato.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(TipoContato obj)
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