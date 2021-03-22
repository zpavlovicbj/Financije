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

            return View(StoreForView(1));
        }

        [HttpGet]
        public IActionResult ViewStorePagination(int pagenum, int botun)
        {
            switch (botun)
            {
                case 1:
                    pagenum = 1;
                    break;
                case 2:
                    pagenum--;
                    break;
                case 3:
                    pagenum++;
                    break;
            };

            return View("StoreView", StoreForView(pagenum));
        }

        public StoreViewModel StoreForView(int pageNumber)
        {
            int startRecord = recPerPage * (pageNumber - 1);
            var (items, count) = _financijeService.GetPaginatedResultStores(startRecord, recPerPage);

            StoreViewModel storeVM = new StoreViewModel();

            storeVM.StoreList = _mapper.Map<List<StorePreviewModel>>(items);
            
            storeVM.ListPageSize = PageCountList();
            storeVM.Page = new Page<StorePreviewModel>(storeVM.StoreList, count, pageNumber, recPerPage);
            storeVM.PageCount = recPerPage;

            return storeVM;
        }

        [HttpPost]
        public IActionResult CreateStore(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var exsist = _financijeService.GetStoreByName(model.StoreName);
                if (exsist == null)
                {
                    _financijeService.AddStore(model.StoreName);
                    return View("StoreView", StoreForView(1));
                }
                else
                {
                    ViewBag.Greska = "Ovaj Primatelj/platitelj već postoji.";
                }
                
            }

            return View("StoreView", StoreForView(1));
        }

        [HttpGet]
        public IActionResult DeleteStore(int Id)
        {
            _financijeService.RemoveStore(Id);
            return View("StoreView", StoreForView(1));
        }


        public IActionResult DescriptionView(int pageNumber)
        {
            if(pageNumber == 0)
            {
                pageNumber = 1;
            }
            return View(DescriptionForView(pageNumber));
        }

        [HttpGet]
        public IActionResult ViewDetailsPagination(int pagenum, int botun)
        {
            switch (botun)
            {
                case 1:
                    pagenum = 1;
                    break;
                case 2:
                    pagenum--;
                    break;
                case 3:
                    pagenum++;
                    break;
            };

            return View("DescriptionView", DescriptionForView(pagenum));
        }

        public DescriptionViewModel DescriptionForView(int pageNumber)
        {
            int startRecord = recPerPage * (pageNumber - 1);
            var (items, count) = _financijeService.GetPaginatedResultDescriptions(startRecord, recPerPage);

            DescriptionViewModel descriptionVM = new DescriptionViewModel();

            descriptionVM.DescriptionList = _mapper.Map<List<DescriptionPreviewModel>>(items);

            descriptionVM.ListPageSize = PageCountList();
            descriptionVM.Page = new Page<DescriptionPreviewModel>(descriptionVM.DescriptionList, count, pageNumber, recPerPage);
            descriptionVM.PageCount = recPerPage;

            return descriptionVM;
        }

        [HttpPost]
        public IActionResult CreateDescription(DescriptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var exsist = _financijeService.GetDescriptionByName(model.DescriptionName);
                if(exsist == null)
                {
                    _financijeService.AddDescription(model.DescriptionName);
                    return View("DescriptionView", DescriptionForView(1));
                }
                else
                {
                    ViewBag.Greska = "Ovaj opis već postoji.";
                }
                
            }

            return View("DescriptionView", DescriptionForView(1));
        }

        [HttpGet]
        public IActionResult DeleteDescription(int Id)
        {
            _financijeService.RemoveDescription(Id);
            return View("DescriptionView", DescriptionForView(1));
        }

        [HttpGet]
        public IActionResult DescriptionEdit(int Id, int currentPage)
        {
            var description = _financijeService.GetDescriptionById(Id);

            DescriptionPreviewModel descriptionPVM = _mapper.Map<DescriptionPreviewModel>(description);
            descriptionPVM.CurrentPage = currentPage;

            return View("DescriptionEditView", descriptionPVM);
        }

        [HttpPost]
        public IActionResult DescriptionEdit(DescriptionPreviewModel model)
        {
            if (ModelState.IsValid)
            {
                var description = _financijeService.GetDescriptionById(model.DescriptionId);
                description.DescriptionName = model.DescriptionName;
                _financijeService.EditDescription();

                return View("DescriptionView", DescriptionForView(model.CurrentPage));
            }

            return View("DescriptionView", DescriptionForView(1));
        }

        public List<int> PageCountList()
        {
            var tempList = new List<int>();
            tempList.Add(5);
            tempList.Add(10);
            tempList.Add(15);
            tempList.Add(20);
            return tempList;
        }
    }
}
