using AutoMapper;
using Financije.Core.Contracts.Services;
using Financije.Core.Entities;
using Financije.Presentation.Models;
using Financije.Presentation.Models.Financije;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
            //return View();
            return RedirectToAction("VeiwAccounts");
        }

        /// <summary>
        /// Prikaz računa
        /// </summary>
        /// <returns></returns>
        public IActionResult VeiwAccounts()
        {
            return View(CreateAccountDataModel(0));
        }

        /// <summary>
        /// Prikaz trgovina
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewStores()
        {
            return View();
        }
        
        /// <summary>
        /// Prikaz opisa
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewDescriptions()
        {
            return View();
        }
    
        /// <summary>
        /// Prikaz artikala
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewArticles()
        {
            ArticlePreviewModel article = new()
            {
                DescriptionsList = _financijeService.GetAllDescriptions()
            };
            return View(article);
        }

        /// <summary>
        /// Unos računa - prikaz view-a
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EnterAccountData(int id = 0)
        {
            return View(CreateAccountDataModel(id));
        }

        /// <summary>
        /// Sprema podatke o unesenom računu
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EnterAccountData(AccountDataCreateModel requestModel)
        {
            var store = _financijeService.GetStoreByName(requestModel.Store);
            var description = _financijeService.GetDescriptionByName(requestModel.Description);

            if (store == null)
            {
                _financijeService.AddStore(requestModel.Store);
                store = _financijeService.GetStoreByName(requestModel.Store);
            }

            if (description == null)
            {
                _financijeService.AddDescription(requestModel.Description);
                description = _financijeService.GetDescriptionByName(requestModel.Description);
            }
            AccountDataCreateModel accountCM;
            if (requestModel.Id > 0)
            {
                Accounts account = _financijeService.GetAccountsById(requestModel.Id);

                account.Date = requestModel.Date;
                account.StoreId = store.StoreId;
                account.DescriptionId = description.DescriptionId;
                account.Payin = Convert.ToDouble(requestModel.Payin);
                account.Payout = Convert.ToDouble(requestModel.Payout);
                account.Month = requestModel.Date.Month;

                _financijeService.EditAccount();
                return RedirectToAction("VeiwAccounts");
            }
            else
            {
                accountCM = new AccountDataCreateModel
                {
                    Date = requestModel.Date,
                    Payin = requestModel.Payin,
                    Payout = requestModel.Payout,
                };
                var acc = _mapper.Map<Accounts>(accountCM);
                acc.StoreId = store.StoreId;
                acc.DescriptionId = description.DescriptionId;
                _financijeService.AddAccount(acc);
            }

            return RedirectToAction("EnterAccountData");
        }

        /// <summary>
        /// Priprema model za unos računa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AccountCreateModel CreateAccountDataModel(int id)
        {
            var accountCM = new AccountCreateModel();

            if (id > 0)
            {
                var account = _financijeService.GetAccountsById(id);
                accountCM = _mapper.Map<AccountCreateModel>(account);
            }
            else
            {
                accountCM.Date = DateTime.Today;
                accountCM.Payin = 0;
                accountCM.Payout = 0;
            }

            accountCM.DescriptionsList = _financijeService.GetAllDescriptions();
            accountCM.StoresList = _financijeService.GetAllStores();
            accountCM.ArticleList = _financijeService.GetAllArticles();

            return accountCM;
        }

        public AccountCreateModel CreateAccountModel(int id=0)
        {
            var accountModel = new AccountCreateModel();

            accountModel.Date = DateTime.Today;

            if (id > 0)
            {
                var account = _financijeService.GetAccountsById(id);
                accountModel = _mapper.Map<AccountCreateModel>(account);
            }
            accountModel.ArticleList = _financijeService.GetAllArticles();
            accountModel.DescriptionsList = _financijeService.GetAllDescriptions();
            accountModel.StoresList = _financijeService.GetAllStores();


            return accountModel;
        }

        //public AccountViewModel CreateAccountForView()
        //{
        //    var listAccounts = _financijeService.GetAllAccounts();
        //    AccountViewModel accountVM = new AccountViewModel
        //    {
        //        Accounts = _mapper.Map<List<AccountPreviewModel>>(listAccounts)
        //    };

        //    return accountVM;
        //}

        [HttpGet]
        public IActionResult EnterAccount()
        {
            return View(CreateAccountModel(21));
        }


        [HttpPost]
        public IActionResult EnterAccount(AccountCreateModel requestModel)
        {
            return View(CreateAccountModel());
        }
    }
}
