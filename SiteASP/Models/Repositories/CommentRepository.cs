using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteASP.Models.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly BlogContext _context;

        public CommentRepository(BlogContext context)
        {
            _context = context;
        }

        public void Create(Comment model)
        {
            if (model != null)
            {
                _context.Comments.Add(model);
            }
        }

        public void Delete(int id)
        {
            var model = Get(id);
            _context.Comments.Remove(model);
        }

        public Comment Get(int id)
        {
            return _context.Comments.Include(a => a.Article).Single(a => a.Id == id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.Include(a => a.Article).ToList();
        }

        public void Update(Comment model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}