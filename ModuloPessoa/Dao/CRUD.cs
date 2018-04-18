using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloPessoa.Dao
{
    interface ICRUD<T, U> 
        where T : class        

    {
        List<T> Listar { get; }

        T Buscar(U id);

        bool Criar(T obj);

        bool Editar(T obj);

        bool Deletar(T obj);        
    }
}
