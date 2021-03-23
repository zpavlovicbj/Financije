using AutoMapper;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Contracts.Services;
using Financije.Core.Entities;
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

        [HttpPost("GetDescriptions")]
        public IActionResult GetDescriptions([FromForm] PagedRQuery model)
        {
            PagedRResult<Descriptions> result = _financijeService.SearchDescriptions(model);

            var finalVM = new DatatableViewModel<DescriptionPreviewModel>
            {
                Data = _mapper.Map<List<DescriptionPreviewModel>>(result.Items),
                Draw = model.Draw,
                RecordsFiltered = result.Count,
                RecordsTotal = result.Count
            };

            return Ok(finalVM);
        }

        [HttpPost("DeleteDescriptions")]
        public IActionResult DeleteDescriptions(int Id)
        {
            var details = _financijeService.GetDescriptionById(Id);
            string message = "";
            if (details != null)
            {
                _financijeService.RemoveDescription(Id);
                //_logger.LogInformation("Certifikat izdan za " + cert.IssuedTo + " je obrisan.");
                message = $"Deleted";
            }
            else
            {
                message = $"Not";
            }
            return Ok(message);
        }

        [HttpGet("AddOrEditDescription")]
        public IActionResult AddOrEditDescription(DescriptionViewModel model)
        {
            return Ok();
        }
    }
}
