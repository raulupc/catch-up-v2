using Microsoft.EntityFrameworkCore;

namespace pc2u202319415.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// Extensiones para ModelBuilder (snake_case).
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public static class ModelBuilderExtensions
{
    public static void ApplySnakeCaseConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .ToList()
            .ForEach(p => p.SetColumnName(SnakeCase(p.Name)));
    }

    private static string SnakeCase(string input)
    {
        return System.Text.RegularExpressions.Regex.Replace(input, @"([a-z])([A-Z])", "$1_$2").ToLower();
    }
}