namespace Bookify.Infrastructre.Configurations;
internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.OwnsOne(a => a.Address);

        builder.Property(a => a.Name)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new Name(value));


        builder.Property(a => a.Description)
          .HasMaxLength(200)
          .HasConversion(description => description.Value, value => new Description(value));


        builder.OwnsOne(a => a.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });


        builder.OwnsOne(a => a.CleaningFee, feeBuilder =>
        {
            feeBuilder.Property(money => money.Currency)
            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });


        builder.Property<uint>("RowVersion").IsRowVersion();

    }
}
