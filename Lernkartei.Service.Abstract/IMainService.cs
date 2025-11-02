using System.Collections.Generic;
using System.Linq;

namespace Lernkartei.Service.Abstract
{
    public interface IMainService<D>
        where D : class , new()
    {
        public IList<D> GetAll();
        public D GetById(dynamic id);
        public D Add(D entity);
        public D Update(D entity);
        public bool Delete(dynamic id);
    }
}
