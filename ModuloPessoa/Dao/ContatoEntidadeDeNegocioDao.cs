using ModuloPessoa.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Controllers
{
    public class ContatoEntidadeDeNegocioDao : ICRUD<ContatoEntidadeDeNegocio, Guid>
    {
        private PessoaConnection db = Singleton.Instance.Context;

        public List<ContatoEntidadeDeNegocio> Listar => db.ContatoEntidadeDeNegocio.Include("EntidadeDeNegocio").Include("Pessoa").Include("TipoContato").ToList();

        public ContatoEntidadeDeNegocio Buscar(Guid id) {
            return db.ContatoEntidadeDeNegocio.FirstOrDefault(x => x.rowguid.Equals(id));
        } 


        public bool Criar(ContatoEntidadeDeNegocio obj)
        {
            try
            {
                obj.rowguid = Guid.NewGuid();
                obj.DataModificacao = DateTime.Now;
                db.ContatoEntidadeDeNegocio.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Deletar(ContatoEntidadeDeNegocio obj)
        {
            try
            {
                db.ContatoEntidadeDeNegocio.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Editar(ContatoEntidadeDeNegocio obj)
        {
            try
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}