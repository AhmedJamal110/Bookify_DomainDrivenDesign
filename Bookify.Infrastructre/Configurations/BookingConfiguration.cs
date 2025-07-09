namespace Bookify.Infrastructre.Configurations;
internal sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasOne<Apartment>()
            .WithMany()
            .HasForeignKey(b => b.ApaermentId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(b => b.UserId);


        builder.OwnsOne(b => b.Duration);

        builder.OwnsOne(a => a.PriceForPeriod, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(a => a.CleaningFee, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(a => a.AmenitiesUpCharge, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(a => a.TotalPrice, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });


    }
}
