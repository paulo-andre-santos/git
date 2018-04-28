using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class EnderecoEmailDao : ICRUD<EnderecoEmail, Guid>
    {
        private PessoaConnection db = new PessoaConnection();

        public EnderecoEmail Buscar(Guid id)
        {
             return db.EnderecoEmail.FirstOrDefault(x => x.rowguid.Equals(id));
        }

        public bool Criar(EnderecoEmail obj)
        {
            try
            {
                obj.rowguid = Guid.NewGuid();
                obj.DataModificacao = DateTime.Now;
                db.EnderecoEmail.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(EnderecoEmail obj)
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

        public bool Deletar(EnderecoEmail obj)
        {
            try
            {
                db.EnderecoEmail.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<EnderecoEmail> Listar => db.EnderecoEmail.Include("Pessoa").ToList();
    }
}