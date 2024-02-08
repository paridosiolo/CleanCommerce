using CleanCommerce.Domain.Category.ValueObjects;
using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Category
{
    public sealed class Category : AggregateRoot<CategoryId>
    {
        private readonly List<CategoryId> _children = new();
        private readonly List<ProductId> _productIds = new();
        public string Name { get; }
        public string Description { get; }
        public Image Image { get; }
        public CategoryId Parent { get; }
        public IReadOnlyList<CategoryId> Children => _children.AsReadOnly();
        public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();

        private Category(CategoryId id,
                        string name,
                        string description,
                        Image image,
                        CategoryId parent,
                        List<CategoryId> children) : base(id)
        {
            Name = name;
            Description = description;
            Image = image;
            Parent = parent;
            _children = children;
        }

        public static Category Create(string name,
                                      string description,
                                      Image image,
                                      CategoryId parent,
                                      List<CategoryId> children)
        {
            return new Category(CategoryId.Create(),
                                name,
                                description,
                                image,
                                parent,
                                children);
        }
    }
}
