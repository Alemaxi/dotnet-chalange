using System.Collections.Generic;
using System.Linq;
using TODOListDDD.api.Data.Converter.Contract;
using TODOListDDD.api.Data.VO;
using TODOListDDD.domain.Entities;

namespace TODOListDDD.api.Data.Converter.Implementations
{
    public class CategoryConverter : IParse<Category, CategoryVO>, IParse<CategoryVO, Category>
    {
        public Category Parse(CategoryVO origin)
        {
            if (origin == null) return null;

            return new Category()
            {
                Id = origin.Id,
                Name = origin.Name,
            };
        }

        public CategoryVO Parse(Category origin)
        {
            if (origin == null) return null;

            return new CategoryVO()
            {
                Id = origin.Id,
                Name = origin.Name,
            };
        }

        public IEnumerable<Category> Parse(IEnumerable<CategoryVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public IEnumerable<CategoryVO> Parse(IEnumerable<Category> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
