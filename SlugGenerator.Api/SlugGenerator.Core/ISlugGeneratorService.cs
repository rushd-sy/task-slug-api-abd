namespace SlugGenerator.Core
{
    public interface ISlugGeneratorService
    {
        string Generate(string text, char separator = '-');
    }
}
