using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainDataContext _context;
        public ProductRepository(MainDataContext context)
        {
            _context = context;
        }

        public Product GetById(Guid id)
        {
            return _context.Products.Include(i => i.SubCategory)
                .ThenInclude(i => i.Category)
                .FirstOrDefault(i => i.Id == id);
        }

        public ICollection<Product> Get()
        {
            return _context.Products.Include(i => i.SubCategory)
                .ThenInclude(i => i.Category).ToList();
        }

        public ICollection<Product> Get(Guid subCategoryId)
        {
            return _context.Products.Where(d => d.SubCategoryId == subCategoryId).ToList();
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var product = _context.Products.FirstOrDefault(i => i.Id == id);
            if (product != null)
                _context.Products.Remove(product);
        }
    }
}
