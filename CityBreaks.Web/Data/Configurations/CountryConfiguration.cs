using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey( c => c.Id);
        builder.Property( c=> c.Id).HasColumnName("country_id");
        builder.Property( c=> c.CountryName).IsRequired().HasMaxLength(100).HasColumnName("country_name");
        builder.Property(c => c.CountryCode).IsRequired().HasMaxLength(3).HasColumnName("country_code");
        builder.HasMany(c => c.Cities).WithOne(city => city.Country).HasForeignKey(city => city.CountryId).OnDelete(DeleteBehavior.Cascade); 
        builder.HasIndex(c => c.CountryCode).IsUnique(); 
    }
}