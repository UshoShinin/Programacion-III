using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorio<T> where T:class
    {
        bool Add(T unObjeto);

        bool Remove(object Id);

        bool Update(T unObjeto);
        
        T FindById(object Id);

        IEnumerable<T> FindAll();
    }
}
