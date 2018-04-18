using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class EstadoProvinciaDao : ICRUD<EstadoProvincia, int>
    {
        private PessoaConnection db = new PessoaConnection();

        public List<EstadoProvincia> Listar => db.EstadoProvincia.Include("Regiao").ToList();

        public EstadoProvincia Buscar(int id) => db.EstadoProvincia.Find(id);

        public bool Criar(EstadoProvincia obj)
        {
            try
            {
                obj.rowguid = Guid.NewGuid();
                obj.DataModificacao = DateTime.Now;
                db.EstadoProvincia.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool Deletar(EstadoProvincia obj)
        {
            try
            {
                db.EstadoProvincia.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(EstadoProvincia obj)
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