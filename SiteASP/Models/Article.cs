using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace SiteASP.Models
{
    public class Article : IEntity
    {
        public int Id { get; set; }

        public string ArticleName { get; set; }

        public DateTime PubDate { get; set; }

        public string ArticleText { get; set; }

        public string ArticleImage { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Article()
        {
            Comments = new List<Comment>();
        }
    }

    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.ArticleName).HasMaxLength(50).IsRequired();
            Property(e => e.PubDate).IsRequired();
            Property(e => e.ArticleText).IsRequired();
            Property(e => e.ArticleImage).IsRequired();
            HasMany(e => e.Comments).WithOptional(e => e.Article).HasForeignKey(e => e.ArticleId);
        }
    }
}