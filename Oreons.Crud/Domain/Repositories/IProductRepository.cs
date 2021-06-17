using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetById(Guid id);
        ICollection<Product> Get();
        ICollection<Product> Get(Guid subCategoryId);
        void Save(Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}
