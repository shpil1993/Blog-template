using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteASP.Models.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly BlogContext _context;

        public CategoryRepository(BlogContext context)
        {
            _context = context;
        }

        public void Create(Category model)
        {
            if (model != null)
            {
                _context.Categories.Add(model);
            }
        }

        public void Delete(int id)
        {
            var model = Get(id);
            _context.Categories.Remove(model);
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}