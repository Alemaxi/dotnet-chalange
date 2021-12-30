using System.Collections.Generic;
using TODOListDDD.domain.Entities.Base;

namespace TODOListDDD.application.Interfaces
{
    public interface IAppServiceBase<T> where T : BaseEntity
    {
        public T Create(T item);
        public void Delete(long id);
        public T Edit(T item);
        public T FindById(long id);
        public List<T> FindAll();
    }
}
