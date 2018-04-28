using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class EnderecoEntidadeDeNegocioDao : ICRUD<EnderecoEntidadeDeNegocio, int>
    {
        private PessoaConnection db = new PessoaConnection();

        public List<EnderecoEntidadeDeNegocio> Listar => db.EnderecoEntidadeDeNegocio.ToList();

        public EnderecoEntidadeDeNegocio Buscar(int id) => db.EnderecoEntidadeDeNegocio.Find(id);

        public bool Criar(EnderecoEntidadeDeNegocio obj)
        {
            try
            {
                obj.rowguid = Guid.NewGuid();
                obj.DataModificacao = DateTime.Now;
                db.EnderecoEntidadeDeNegocio.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool Deletar(EnderecoEntidadeDeNegocio obj)
        {
            try
            {
                db.EnderecoEntidadeDeNegocio.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(EnderecoEntidadeDeNegocio obj)
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