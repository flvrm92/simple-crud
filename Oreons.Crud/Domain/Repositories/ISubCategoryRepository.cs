using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ISubCategoryRepository
    {
        SubCategory GetById(Guid id);
        ICollection<SubCategory> Get();
        ICollection<SubCategory> Get(Guid categoryId);
        void Save(SubCategory subCategory);
        void Update(SubCategory subCategory);
        void Delete(Guid id);
    }
}
