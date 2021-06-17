using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly MainDataContext _context;

        public SubCategoryRepository(MainDataContext context)
        {
            _context = context;
        }

        public SubCategory GetById(Guid id)
        {
            return _context.SubCategories.FirstOrDefault(i => i.Id == id);
        }

        public ICollection<SubCategory> Get()
        {
            return _context.SubCategories.Include(i => i.Category).ToList();
        }

        public ICollection<SubCategory> Get(Guid categoryId)
        {
            return _context.SubCategories.Where(i => i.CategoryId == categoryId).ToList();
        }

        public void Save(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
        }

        public void Update(SubCategory subCategory)
        {
            _context.Entry(subCategory).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var subcategory = _context.SubCategories.FirstOrDefault(i => i.Id == id);
            if (subcategory != null)
                _context.SubCategories.Remove(subcategory);
        }
    }
}
