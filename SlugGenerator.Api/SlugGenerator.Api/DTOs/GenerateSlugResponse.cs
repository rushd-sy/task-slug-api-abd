namespace SlugGenerator.Api.DTOs
{
    public record GenerateSlugResponse(string OriginalText, string Slug, DateTime GeneratedAt);
}
