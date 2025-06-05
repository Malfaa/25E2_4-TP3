using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("city_id");
        builder.Property(c => c.Name).IsRequired().HasMaxLength(150).HasColumnName("city_name");
        builder.Property(c => c.CountryId).HasColumnName("country_id_fk");
        builder.HasMany(c => c.Properties).WithOne(p => p.City).HasForeignKey(p => p.CityId).OnDelete(DeleteBehavior.Cascade);	
    }
}