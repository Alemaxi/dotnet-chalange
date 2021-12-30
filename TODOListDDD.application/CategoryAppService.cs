using System.Collections.Generic;
using TODOListDDD.application.Interfaces;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Services;

namespace TODOListDDD.application
{
    public class CategoryAppService : ICategoryAppService
    {
        protected readonly ICategoryService _service;

        public CategoryAppService(ICategoryService service)
        {
            _service = service;
        }

        public Category Create(Category item)
        {
            return _service.Create(item);
        }

        public void Delete(long id)
        {
            _service.Delete(id);
        }

        public Category Edit(Category item)
        {
            return _service.Edit(item);
        }

        public List<Category> FindAll()
        {
            return _service.FindAll();
        }

        public Category FindById(long id)
        {
            return _service.FindById(id);
        }
    }
}
