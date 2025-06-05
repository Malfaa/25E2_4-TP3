using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("property_id");
        builder.Property(p => p.Name).IsRequired().HasMaxLength(255).HasColumnName("property_name");
        builder.Property(p => p.PricePerNight).IsRequired().HasColumnType("decimal(18,2)").HasColumnName("price_per_night");
        builder.Property(p => p.CityId).HasColumnName("city_id_fk");
		
    }
}