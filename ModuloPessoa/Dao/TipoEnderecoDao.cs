using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class TipoEnderecoDao : ICRUD<TipoEndereco, int>
    {
        private PessoaConnection db = Singleton.Instance.Context;

        public TipoEndereco Buscar(int id) => db.TipoEndereco.Find(id);

        public bool Criar(TipoEndereco obj)
        {
            try
            {
                obj.DataModificacao = DateTime.Now;
                obj.rowguid = Guid.NewGuid();
                db.TipoEndereco.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(TipoEndereco obj)
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

        public bool Deletar(TipoEndereco obj)
        {
            try
            {
                db.TipoEndereco.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<TipoEndereco> Listar => db.TipoEndereco.ToList();      
    }
}