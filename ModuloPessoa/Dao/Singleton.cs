using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ModuloPessoa.Dao
{
    public class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private readonly PessoaConnection context;
        private Singleton()
        {
            context = new PessoaConnection();
        }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public PessoaConnection Context
        {
            get
            {
                return context;
            }
        }
    }
}