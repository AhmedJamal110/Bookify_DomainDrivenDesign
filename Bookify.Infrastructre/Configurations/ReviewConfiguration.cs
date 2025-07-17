using Bookify.Domain.Reviews;

namespace Bookify.Infrastructre.Configurations;
public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");

        builder.HasKey(r => r.Id);

        //builder.Property(review => review.Rating)
        //    .HasConversion(rating => rating.Value, value => Rating.(value).Value);

    }
}
