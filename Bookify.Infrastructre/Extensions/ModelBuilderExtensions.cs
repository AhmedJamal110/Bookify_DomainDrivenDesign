namespace Bookify.Infrastructre.Extensions;
internal static class ModelBuilderExtensions
{
    internal static void ApplyDeciamalConfiguration(this ModelBuilder modelBuilder)
    {
        var decimalType = modelBuilder.Model.GetEntityTypes()
            .SelectMany(type => type.GetProperties())
            .Where(prop => prop.ClrType == typeof(decimal) || prop.ClrType == typeof(decimal?));


        foreach (var prop in decimalType)
        {
            prop.SetColumnType("decimal(18,2)");
        }
    }

    internal static void ApplyRestrictRelationConfigration(this ModelBuilder modelBuilder)
    {
        var cascadeFks = modelBuilder.Model.GetEntityTypes()
            .SelectMany(type => type.GetForeignKeys())
            .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);

        foreach (var fk in cascadeFks)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

    }
}
