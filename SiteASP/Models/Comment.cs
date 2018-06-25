using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace SiteASP.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }

        public string CommentatorName { get; set; }

        public string Email { get; set; }

        public string CommentText { get; set; }

        public DateTime PubDate { get; set; }

        public int? ArticleId { get; set; }

        public Article Article { get; set; }
    }

    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.CommentatorName).HasMaxLength(50).IsRequired();
            Property(e => e.Email).HasMaxLength(50).IsOptional();
            Property(e => e.CommentText).IsRequired();
            Property(e => e.PubDate).IsRequired();
        }
    }
}