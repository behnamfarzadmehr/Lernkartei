using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lernkartei.InfraStructure.Mappings.Card
{
    internal partial class CardMapping : IEntityTypeConfiguration<Domain.Entities.Card>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Card> builder)
        {
            builder.ToTable("Card", "Crd");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Front).HasColumnName("Front").HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            builder.Property(c => c.Back).HasColumnName("Back").HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            builder.Property(c => c.Perfekt).HasColumnName("Perfekt").HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(c => c.WordTypes).HasColumnName("WordTypes").HasColumnType("int").IsRequired();
            builder.Property(c => c.Plural).HasColumnName("Plural").HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(c => c.Artikle).HasColumnName("Artikle").HasColumnType("int").IsRequired();
        }
    }
}
