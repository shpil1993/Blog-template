using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteASP.Models.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context)
        {
            _context = context;
        }

        public void Create(Article model)
        {
            if (model != null)
            {
                _context.Articles.Add(model); 
            }
        }

        public void Delete(int id)
        {
            var model = Get(id);
            _context.Articles.Remove(model);
        }

        public Article Get(int id)
        {
            return _context.Articles.Find(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles.Include(c => c.Category).ToList();
        }

        public void Update(Article model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}