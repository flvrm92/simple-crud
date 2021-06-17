using Shared.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SubCategory : Entity
    {
        protected SubCategory() { }
        public SubCategory(string name, Guid categoryId)
        {
            Name = name;
            CategoryId = categoryId;

            Products = new List<Product>();
        }

        public string Name { get; private set; }

        public virtual Category Category { get; protected set; }
        public Guid CategoryId { get; private set; }

        public ICollection<Product> Products { get; private set; }

        public void Update(string name, Guid categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
