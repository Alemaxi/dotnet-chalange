using System;
using System.Collections.Generic;
using System.Text;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Repositories;
using TODOListDDD.domain.Interfaces.Services;

namespace TODOListDDD.domain.Services
{
    public class CategoryService : ICategoryService
    {
        protected readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Category Create(Category item)
        {
            return _repository.Create(item);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Category Edit(Category item)
        {
            return _repository.Edit(item);
        }

        public List<Category> FindAll()
        {
            return _repository.FindAll();
        }

        public Category FindById(long id)
        {
            return _repository.FindById(id);
        }
    }
}
