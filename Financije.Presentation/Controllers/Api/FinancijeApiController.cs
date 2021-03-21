using AutoMapper;
using Financije.Core.Contracts.Services;
using Financije.Presentation.Models.Financije;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financije.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancijeApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFinancijeService _financijeService;

        public FinancijeApiController(IMapper mapper, IFinancijeService financijeService)
        {
            _mapper = mapper;
            _financijeService = financijeService;
        }

        [HttpGet("GetDescriptionDetails")]
        public IActionResult GetDescriptionDetails(int Id)
        {
            DescriptionPreviewModel description = _mapper.Map<DescriptionPreviewModel>(_financijeService.GetDescriptionById(Id));
            var jsonData = new { data = description };
            return Ok(jsonData);
        }
    }
}
