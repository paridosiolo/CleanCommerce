using CleanCommerce.Domain.Categories.ValueObjects;
using CleanCommerce.Domain.Common.Models;
using CleanCommerce.Domain.Common.ValueObjects;
using CleanCommerce.Domain.Products;
using CleanCommerce.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Categories
{
    public sealed class Category : AggregateRoot<CategoryId>
    {
        private readonly List<CategoryId> _children = new();
        private readonly List<ProductId> _productIds = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Image Image { get; private set; }
        public CategoryId Parent { get; private set; }
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

        public Category Update(
            string name,
            string description,
            Image image,
            CategoryId parent,
            List<CategoryId> children)
        {
            // Update the properties of the Category object
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.Parent = parent;

            //update children categories
            this._children.Clear();
            this._children.AddRange(children);

            return this;
        }
    }
}
