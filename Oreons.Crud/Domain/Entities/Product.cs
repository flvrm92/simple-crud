using Shared.Entities;
using System;

namespace Domain.Entities
{
    public class Product : Entity
    {
        protected Product() { }
        public Product(string name, Guid subCategoryId)
        {
            Name = name;
            SubCategoryId = subCategoryId;
        }

        public string Name { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public Guid SubCategoryId { get; set; }

        public void Update(string name, Guid subCategoryId)
        {
            Name = name;
            SubCategoryId = subCategoryId;
        }
    }
}
