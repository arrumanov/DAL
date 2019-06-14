using Garden.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garden.DAL.Mapping
{ 
    public class MapArticle : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id);
            builder.ToTable("Articles");

            builder.Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.Date)
                .IsRequired();

            builder.Property(a => a.CategoryType)
                .IsRequired();

            builder.Property(a => a.Content)
                .IsRequired();
        }
    }
}
