using AutoMapper;
using Financije.Core.Contracts.Services;
using Financije.Presentation.Models;
using Financije.Presentation.Models.Financije;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Financije.Presentation.Controllers
{
    public class FinancijeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFinancijeService _financijeService;
        public static int recPerPage = 10;

        public FinancijeController(IMapper mapper, IFinancijeService financijeService)
        {
            _mapper = mapper;
            _financijeService = financijeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StoreView()
        {
            return View();
        }
        
        public IActionResult DescriptionView()
        {
            return View();
        }
    
        public IActionResult ArticleView()
        {
            /*Ovako bi vratilo listu bez paginacije
             * var articleVM = new ArticleViewModel();
            
            articleVM.ArticlesList = _mapper.Map<List<ArticlePreviewModel>>(_financijeService.GetAllArticles());

            return View(articleVM);*/
            return View();
        }
    }
}
