using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusADO.UI.Web.Data
{
    interface IGerenciaCRUD<TEntity> where TEntity : class
    {
        List<TEntity> Get();
        TEntity GetById(int? id);
        void Cadastra(TEntity obj);
        void Atualiza(TEntity obj);
        void Exclui(int id);
    }
}
