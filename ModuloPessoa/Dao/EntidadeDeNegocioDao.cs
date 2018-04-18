using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class EntidadeDeNegocioDao : ICRUD<EntidadeDeNegocio, int>
    {
        private PessoaConnection db = new PessoaConnection();

        public List<EntidadeDeNegocio> Listar => db.EntidadeDeNegocio.Include("Pessoa").ToList();

        public EntidadeDeNegocio Buscar(int id) => db.EntidadeDeNegocio.Find(id);

        public bool Criar(EntidadeDeNegocio obj)
        {
            try
            {
                obj.rowguid = Guid.NewGuid();                
                obj.DataModificacao = DateTime.Now;
                db.EntidadeDeNegocio.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool Deletar(EntidadeDeNegocio obj)
        {
            try
            {
                db.EntidadeDeNegocio.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(EntidadeDeNegocio obj)
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