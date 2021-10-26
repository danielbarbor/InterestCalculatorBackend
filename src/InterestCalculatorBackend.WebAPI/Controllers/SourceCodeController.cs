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
        
        /// <summary>
        /// Responsible for informing the url of where the remote source code repository is located
        /// </summary>
        /// <returns>A url string</returns>
        [HttpGet("/showmethecode")]
        public ActionResult<string> GetSourceCodeInfo()
        {
            var info = _sourceCodeService.ShowMeTheCode();

            return info.SourceCodeUrl;
            
        }
    }
}