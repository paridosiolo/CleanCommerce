﻿using CleanCommerce.Application.Common.Interfaces.Persistence;
using CleanCommerce.Domain.Categories;
using CleanCommerce.Domain.Categories.ValueObjects;
using CleanCommerce.Domain.Common.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private static List<Category> _categories = new(); 
        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public Category? GetById(Guid categoryId)
        {
            return _categories.FirstOrDefault(p => p.Id.Value == categoryId);
        }

        public bool Delete(Category category)
        {
            return _categories.Remove(category);
        }
        public Category? Update(Guid toUpdateId, 
                                    string name,
                                    string description,
                                    Image image,
                                    CategoryId parent,
                                    List<CategoryId> children) 
        {
            var toUpdate = GetById(toUpdateId);
            return toUpdate?.Update(name,
                                    description,
                                    image,
                                    parent,
                                    children.ToList());
        }
    }
}
