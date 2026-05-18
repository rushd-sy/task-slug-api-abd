using Microsoft.AspNetCore.Mvc;
using SlugGenerator.Api.DTOs;
using SlugGenerator.Core;
using Asp.Versioning;



namespace SlugGenerator.Api.Controllers;
    [ApiController] 
    [ApiVersion("1.0")] 
    [Route("api/v{version:apiVersion}/[controller]")] 
    public class SlugController : ControllerBase
    {
    private readonly ISlugGeneratorService _generatorService;

    public SlugController(ISlugGeneratorService GeneratorService)
    {
        _generatorService = GeneratorService;
    }

    [HttpPost("Generate")]
        public IActionResult GenerateSlug(GenerateSlugRequest request)
        {
            string slug = _generatorService.Generate(request.Text, request.Separator);

        var response = new GenerateSlugResponse(
            OriginalText: request.Text,
            Slug: slug,
            GeneratedAt: DateTime.UtcNow
        );

            return Ok(response);
        }
    }

