using AutoMapper;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Contracts.Services;
using Financije.Core.Entities;
using Financije.Presentation.Models.Financije;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpPost("GetArticles")]
        public IActionResult GetArticles([FromForm] PagedRQuery model)
        {
            PagedRResult<Articles> result = _financijeService.SearchArticles(model);

            var finalVM = new DatatableViewModel<ArticlePreviewModel>
            {
                Data = _mapper.Map<List<ArticlePreviewModel>>(result.Items),
                Draw = model.Draw,
                RecordsFiltered = result.Count,
                RecordsTotal = result.Count
            };

            return Ok(finalVM);
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

        [HttpPost("GetStores")]
        public IActionResult GetStores([FromForm] PagedRQuery model)
        {
            PagedRResult<Stores> result = _financijeService.SearchStores(model);

            var finalVM = new DatatableViewModel<StorePreviewModel>
            {
                Data = _mapper.Map<List<StorePreviewModel>>(result.Items),
                Draw = model.Draw,
                RecordsFiltered = result.Count,
                RecordsTotal = result.Count
            };

            return Ok(finalVM);
        }

        [HttpGet("GetArticleDetails")]
        public IActionResult GetArticleDetails(int Id)
        {
            ArticlePreviewModel article = _mapper.Map<ArticlePreviewModel>(_financijeService.GetArticlesById(Id));
            var jsonData = new { data = article };
            return Ok(jsonData);
        }

        [HttpGet("GetDescriptionDetails")]
        public IActionResult GetDescriptionDetails(int Id)
        {
            DescriptionPreviewModel description = _mapper.Map<DescriptionPreviewModel>(_financijeService.GetDescriptionById(Id));
            var jsonData = new { data = description };
            return Ok(jsonData);
        }

        [HttpGet("GetStoreDetails")]
        public IActionResult GetStoreDetails(int Id)
        {
            StorePreviewModel store = _mapper.Map<StorePreviewModel>(_financijeService.GetStoreById(Id));
            var jsonData = new { data = store };
            return Ok(jsonData);
        }

        [HttpPost("DeleteArticles")]
        public IActionResult DeleteArticles(int Id)
        {
            var article = _financijeService.GetArticlesById(Id);
            string message = "";
            if(article != null)
            {
                _financijeService.RemoveArticles(Id);
                message = $"Deleted";
            }
            else
            {
                message = $"Not";
            }
            return Ok(message);
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

        [HttpPost("DeleteStores")]
        public IActionResult DeleteStores(int Id)
        {
            var details = _financijeService.GetStoreById(Id);
            string message = "";
            if (details != null)
            {
                _financijeService.RemoveStore(Id);
                //_logger.LogInformation("Certifikat izdan za " + cert.IssuedTo + " je obrisan.");
                message = $"Deleted";
            }
            else
            {
                message = $"Not";
            }
            return Ok(message);
        }

        [HttpPost("AddOrEditArticle")]
        public IActionResult AddOrEditArticle([FromBody] ArticlePreviewModel model)
        {
            string message = "";
            if (model.ArticleId != 0)
            {
                var article = _financijeService.GetArticlesById(model.ArticleId);
                article.ArticleName = model.ArticleName;
                var description = _financijeService.GetDescriptionByName(model.DescriptionName);
                article.DescriptionId = description.DescriptionId;
                _financijeService.EditArticle();
                message = $"OK";
            }
            else
            {
                var description = _financijeService.GetDescriptionByName(model.DescriptionName);
                
                _financijeService.AddArticles(model.ArticleName, description.DescriptionId);
                message = $"OK";
            }
            return Ok(message);
        }

        [HttpPost("AddOrEditDescription")]
        public IActionResult AddOrEditDescription([FromBody] DescriptionPreviewModel model)
        {
            string message = "";
            if (model.DescriptionId != 0)
            {
                var description = _financijeService.GetDescriptionById(model.DescriptionId);
                description.DescriptionName = model.DescriptionName;
                _financijeService.EditDescription();
                message = $"OK";
            }
            else
            {
                _financijeService.AddDescription(model.DescriptionName);
                message = $"OK";
            }
            return Ok(message);
        }

        [HttpPost("AddOrEditStore")]
        public IActionResult AddOrEditStore([FromBody] StorePreviewModel model)
        {
            string message = "";
            if (model.StoreId != 0)
            {
                var description = _financijeService.GetStoreById(model.StoreId);
                description.StoreName = model.StoreName;
                _financijeService.EditStore();
                message = $"OK";
            }
            else
            {
                _financijeService.AddStore(model.StoreName);
                message = $"OK";
            }
            return Ok(message);
        }

    }
}
