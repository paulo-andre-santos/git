using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModuloPessoa.Dao
{
    public class RegiaoDao : ICRUD<Regiao, string>
    {
        private PessoaConnection db = new PessoaConnection();

        public List<Regiao> Listar => db.Regiao.ToList();

        public Regiao Buscar(string id) => db.Regiao.Find(id);

        public bool Criar(Regiao obj)
        {
            try
            {
                obj.DataModificacao = DateTime.Now;
                db.Regiao.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool Deletar(Regiao obj)
        {
            try
            {
                db.Regiao.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Regiao obj)
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