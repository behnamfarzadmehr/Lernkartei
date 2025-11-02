using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lernkartei.InfraStructure.Mappings.Card
{
    internal partial class CardHousMapping : IEntityTypeConfiguration<Domain.Entities.CardHouse>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.CardHouse> builder)
        {
            builder.ToTable("CardHouse", "Crd");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.CardId).HasColumnName("CardId").IsRequired();
            builder.Property(c => c.House).HasColumnName("House").IsRequired();
            builder.Property(c => c.ActionDate).HasColumnName("ActionDate").IsRequired();
            builder.Property(c => c.Lerned).HasColumnName("Lerned").IsRequired();

            //foreignkey
            builder.HasOne(c => c.Card).WithMany(s => s.CardHouse).HasForeignKey(c => c.CardId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
