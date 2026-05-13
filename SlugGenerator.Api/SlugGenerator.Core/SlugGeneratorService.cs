namespace SlugGenerator.Core
{
    public class SlugGeneratorService : ISlugGeneratorService
    {
        public string Generate(string text, char separator = '-')
        {
            ArgumentNullException.ThrowIfNull(text);

            return string.Join(separator, text
            .Where(ch => char.IsLetter(ch) || ch == ' ' || ch == separator)
            .ToArray()
            .AsMemory()
            .ToString()
            .ToLowerInvariant()
            .Split(new[] { ' ', separator }, StringSplitOptions.RemoveEmptyEntries)
);
        }

        public string GenerateUnique(string text)
        {
            ArgumentNullException.ThrowIfNull(text);

            System.Guid uniqueId = System.Guid.NewGuid();
            return $"{Generate(text)}-{uniqueId}";
        }
    }
}
