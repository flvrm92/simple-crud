using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MainDataContext _context;
        public CategoryRepository(MainDataContext context)
        {
            _context = context;
        }

        public Category GetById(Guid id)
        {
            return _context.Categories.FirstOrDefault(i => i.Id == id);
        }

        public ICollection<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public void Save(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var category = _context.Categories.FirstOrDefault(i => i.Id == id);
            if (category != null)
                _context.Categories.Remove(category);
        }
    }
}
