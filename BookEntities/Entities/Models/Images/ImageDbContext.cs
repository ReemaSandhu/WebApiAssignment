using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookEntities.Entities.Models.Images
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext()
        {
        }

        public ImageDbContext(DbContextOptions<ImageDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Image { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity => { });
        }
    }
}
