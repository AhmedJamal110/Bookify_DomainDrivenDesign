namespace Bookify.Infrastructre.Configurations;
internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(a => a.Id);

         
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(a => a.FirstName)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new FirstName(value));


        builder.Property(a => a.LastName)
          .HasMaxLength(200)
          .HasConversion(description => description.Value, value => new LastName(value));

        builder.Property(a => a.Email)
          .HasMaxLength(200)
          .HasConversion(description => description.Value, value => new Domain.Users.Email(value));




    }
}
