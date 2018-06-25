using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace SiteASP.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public ICollection<Article> Articles { get; set; }

        public Category()
        {
            Articles = new List<Article>();
        }
    }

    class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.CategoryName).IsOptional();
            HasMany(e => e.Articles).WithOptional(e => e.Category).HasForeignKey(e => e.CategoryId);
        }
    }
}