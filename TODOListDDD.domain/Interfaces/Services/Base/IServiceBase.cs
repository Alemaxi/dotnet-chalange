using System;
using System.Collections.Generic;
using System.Text;
using TODOListDDD.domain.Entities.Base;

namespace TODOListDDD.domain.Interfaces.Services.Base
{
    public interface IServiceBase<T> where T : BaseEntity
    {
        public T Create(T item);
        public void Delete(long id);
        public T Edit(T item);
        public T FindById(long id);
        public List<T> FindAll();
    }
}
