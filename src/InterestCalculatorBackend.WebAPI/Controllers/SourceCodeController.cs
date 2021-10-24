using System;
using InterestCalculatorBackend.Abstractions.Application;
using InterestCalculatorBackend.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterestCalculatorBackend.WebAPI.Controllers
{
    public class SourceCodeController : ControllerBase
    {
        private readonly ILogger<SourceCodeController> _logger;

        private readonly ISourceCodeService<SourceCodeInfoDto> _sourceCodeService;

        public SourceCodeController(ILogger<SourceCodeController> logger, ISourceCodeService<SourceCodeInfoDto> sourceCodeService)
        {
            _logger = logger;
            _sourceCodeService = sourceCodeService;
        }

        [HttpGet("/showmethecode")]
        public ActionResult<SourceCodeInfoDto> GetSourceCodeInfo()
        {
            try
            {
                var info = _sourceCodeService.ShowMeTheCode();

                return info;
            }
            catch (Exception e)
            {
                _logger.LogError($"A error has occured while attending the request, {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}