using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookEntities.Entities.Models.CommentsFolder
{
   public class CommentDbContext : DbContext
    {
        public CommentDbContext()
        {
        }

        public CommentDbContext(DbContextOptions<CommentDbContext> options)
            : base(options)
        {
        }

        public virtual System.Data.Entity.DbSet<AddComments> AddComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddComments>(entity => { });
        }
    }
}
