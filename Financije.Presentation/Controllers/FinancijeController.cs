using AutoMapper;
using Financije.Core.Contracts.Services;
using Financije.Presentation.Models.Financije;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Financije.Presentation.Controllers
{
    public class FinancijeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFinancijeService _financijeService;

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

            return View(StoreViewModel());
        }

        public StoreViewModel StoreViewModel()
        {
            List<Financije.Core.Entities.Stores> storesList = _financijeService.GetAll();

            StoreViewModel storeVM = new StoreViewModel();

            storeVM.StoreList = _mapper.Map<List<StorePreviewModel>>(storesList);

            return storeVM;
        }

        [HttpPost]
        public IActionResult CreateStore(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                _financijeService.Add(model.StoreName);
                return View("StoreView", StoreViewModel());
            }

            return View("StoreView", StoreViewModel());
        }

        [HttpGet]
        public IActionResult DeleteStore(int Id)
        {
            _financijeService.Remove(Id);
            return View("StoreView", StoreViewModel());
        }
    }
}
