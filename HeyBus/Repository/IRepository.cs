using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeyBus.Repository
{
    internal interface IRepository<Y>
    {
        IEnumerable<Y> GetAll();
        Y GetById(int id);
        void Create(Y t);
        void Update(Y t);
        void Delete(Y t);
    }
}
