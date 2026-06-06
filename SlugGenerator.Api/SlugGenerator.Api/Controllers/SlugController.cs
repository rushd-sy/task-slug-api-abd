using Microsoft.AspNetCore.Mvc;
using SlugGenerator.Api.DTOs;
using SlugGenerator.Core;
using FluentValidation;
using Asp.Versioning;


namespace SlugGenerator.Api.Controllers;
    [ApiController] 
    [ApiVersion("1.0")] 
    [Route("api/v{version:apiVersion}/[controller]")] 
    public class SlugController : ControllerBase
    {
    private readonly ISlugGeneratorService _generatorService;
    private readonly IValidator<GenerateSlugRequest> _validator;
    public SlugController(ISlugGeneratorService generatorService, IValidator<GenerateSlugRequest> validator)
    {
        _generatorService = generatorService;
        _validator = validator;
    }

    [HttpPost("Generate")]
        public IActionResult GenerateSlug(GenerateSlugRequest request)
        {

        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }


        string slug = _generatorService.Generate(request.Text, request.Separator ?? '-');

        var response = new GenerateSlugResponse(
            OriginalText: request.Text,
            Slug: slug,
            GeneratedAt: DateTime.UtcNow
        );

            return Ok(response);
        }
    }

