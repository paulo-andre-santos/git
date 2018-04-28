using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class TelefonePessoaDao : ICRUD<TelefonePessoa, int>
    {
        private PessoaConnection db = new PessoaConnection();

        public List<TelefonePessoa> Listar => db.TelefonePessoa.Include("Pessoa").Include("TipoNumeroTelefone").ToList();

        public TelefonePessoa Buscar(int id) {
            return db.TelefonePessoa.FirstOrDefault( x=> x.EntidadeDeNegocioID.Equals(id));
        }

        public bool Criar(TelefonePessoa obj)
        {
            try
            {
                obj.DataModificacao = DateTime.Now;
                db.TelefonePessoa.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool Deletar(TelefonePessoa obj)
        {
            try
            {
                db.TelefonePessoa.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(TelefonePessoa obj)
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