using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Category GetById(Guid id);
        ICollection<Category> Get();
        void Save(Category category);
        void Update(Category category);
        void Delete(Guid id);
    }
}
