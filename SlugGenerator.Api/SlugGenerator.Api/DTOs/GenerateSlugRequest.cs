using Microsoft.Extensions.Options;

namespace SlugGenerator.Api.DTOs
{
    public record GenerateSlugRequest(string Text, char? Separator = '-');
}
