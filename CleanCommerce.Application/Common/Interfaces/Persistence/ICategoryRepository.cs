using CleanCommerce.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Application.Common.Interfaces.Persistence
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category? GetById(Guid categoryId);
        bool Delete(Category category);
        Category? Update(Guid toUpdateId, Category updated);
    }
}
