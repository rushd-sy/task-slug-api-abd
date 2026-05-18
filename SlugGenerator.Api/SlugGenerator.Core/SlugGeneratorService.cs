using ClassLibrary_Slug_Generator_Abd;
namespace SlugGenerator.Core
{
    public class SlugGeneratorService : ISlugGeneratorService
    {
        public string Generate(string text, char separator = '-')
        {
            ArgumentNullException.ThrowIfNull(text);

            return ClassLibrary_Slug_Generator_Abd.SlugGenerator.Generate(text, separator);
        }

        public string GenerateUnique(string text)
        {
            ArgumentNullException.ThrowIfNull(text);

            return ClassLibrary_Slug_Generator_Abd.SlugGenerator.GenerateUnique(text);
        }
    }
}
