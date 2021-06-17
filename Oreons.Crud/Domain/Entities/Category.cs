using Shared.Entities;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category : Entity
    {
        protected Category() { }
        public Category(string name)
        {
            Name = name;

            SubCategories = new List<SubCategory>();
        }

        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; protected set; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
