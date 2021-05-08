using AutoMapper;
using Financije.Core.Contracts.Repositories.Models;
using Financije.Core.Contracts.Services;
using Financije.Core.Entities;
using Financije.Presentation.Models.Financije;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost("AddOrEditAccountDetails")]
        public IActionResult AddOrEditAccountDetails([FromBody] AccountDetailsModel model)
        {
            Accounts account = _financijeService.GetAccountsByName(model.AccountNumber);

            Stores store = _financijeService.GetStoreByName(model.Store);
            if (model.Id == 0)
            {
                if (account == null)
                {
                    Accounts newAccount = new Accounts
                    {
                        Date = model.AccountDate,
                        AccountNumber = model.AccountNumber,
                        StoreId = store.StoreId,
                        DescriptionId = 1,
                        Payin = 0,
                        Payout = 0,
                        Month = model.AccountDate.Month
                    };
                    _financijeService.AddAccountDetail(newAccount);
                    int lastId = _financijeService.GetLastAccountId();
                    return Ok(lastId);
                }
                else
                {
                    return Ok("Duplo");
                }
            }
            else
            {
                account.Date = model.AccountDate;
                account.AccountNumber = model.AccountNumber;
                account.StoreId = store.StoreId;
                account.DescriptionId = 1;
                account.Payin = 0;
                account.Payout = 0;
                account.Month = model.AccountDate.Month;
                _financijeService.EditAccount();
                return Ok(account.AccountId);
            }
        }

        /// <summary>
        /// Sprema promijene na računu (AccountData)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddOrEditAccountData")]
        public IActionResult AddOrEditAccountData([FromBody] AccountDetailsModel model)
        {
            var store = _financijeService.GetStoreByName(model.Store);
            var description = _financijeService.GetDescriptionByName(model.Description);

            if (store == null)
            {
                _financijeService.AddStore(model.Store);
                store = _financijeService.GetStoreByName(model.Store);
            }

            if (description == null)
            {
                _financijeService.AddDescription(model.Description);
                description = _financijeService.GetDescriptionByName(model.Description);
            }

            Accounts account = _financijeService.GetAccountsById(model.Id);

            account.Date = model.AccountDate;
            account.StoreId = store.StoreId;
            account.DescriptionId = description.DescriptionId;
            account.Payin = Convert.ToDouble(model.Payin);
            account.Payout = Convert.ToDouble(model.Payout);
            account.Month = model.AccountDate.Month;

            _financijeService.EditAccount();

            return Ok("OK");
        }

        /// <summary>
        /// Prikaz računa
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("GetAccounts")]
        public IActionResult GetAccounts([FromForm] PagedRQuery model)
        {
            PagedRResult<Accounts> result = _financijeService.SearchAccounts(model);

            var finalVM = new DatatableViewModel<AccountPreviewModel>
            {
                Data = _mapper.Map<List<AccountPreviewModel>>(result.Items),
                Draw = model.Draw,
                RecordsFiltered = result.Count,
                RecordsTotal = result.Count
            };

            return Ok(finalVM);
        }

        [HttpPost("DeleteAccount")]
        public IActionResult DeleteAccount(int Id)
        {
            var account = _financijeService.GetAccountsById(Id);
            string message;
            if (account != null)
            {
                _financijeService.RemoveAccount(Id);
                message = $"Deleted";
            }
            else
            {
                message = $"Not";
            }
            return Ok(message);


        }


        [HttpPost("GetAccountsItems")]
        public IActionResult GetAccountsItems([FromForm] PagedRQuery model, int Id)
        {
            PagedRResult<AccountItems> result = _financijeService.SearchAccountItems(model, Id);

            var finalVM = new DatatableViewModel<AccountCreateModel>
            {
                Data = _mapper.Map<List<AccountCreateModel>>(result.Items),
                Draw = model.Draw,
                RecordsFiltered = result.Count,
                RecordsTotal = result.Count
            };

            return Ok(finalVM);
        }

        /// <summary>
        /// Prikaz artikala
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Dohvaćanje detalja artikala
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetArticleDetails")]
        public IActionResult GetArticleDetails(int Id)
        {
            ArticlePreviewModel article = _mapper.Map<ArticlePreviewModel>(_financijeService.GetArticlesById(Id));
            var jsonData = new { data = article };
            return Ok(jsonData);
        }

        /// <summary>
        /// Dodaje artikl
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddOrEditArticle")]
        public IActionResult AddOrEditArticle([FromBody] ArticlePreviewModel model)
        {
            string message;
            if (model.ArticleId != 0)
            {
                var article = _financijeService.GetArticlesById(model.ArticleId);
                article.ArticleName = model.ArticleName;
                article.ArticleNameUC = model.ArticleName.ToUpper();
                var description = _financijeService.GetDescriptionByName(model.DescriptionName);
                article.DescriptionId = description.DescriptionId;
                _financijeService.EditArticle();
                message = $"OK";
            }
            else
            {
                var article = _financijeService.GetArticlesByName(model.ArticleName);
                if (article == null)
                {
                    var description = _financijeService.GetDescriptionByName(model.DescriptionName);

                    _financijeService.AddArticles(model.ArticleName, description.DescriptionId);
                    message = $"OK";
                }
                else
                {
                    return NotFound("Dupli");
                }
            }
            return Ok(message);
        }

        /// <summary>
        /// Brisanje artikala
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("DeleteArticles")]
        public IActionResult DeleteArticles(int Id)
        {
            var article = _financijeService.GetArticlesById(Id);
            string message;
            if (article != null)
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

        /// <summary>
        /// Dodavanje stavaka računa
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddArticleItem")]
        public IActionResult AddArticleItem([FromBody] AccountItemModel model)
        {
            Articles article = _financijeService.GetArticlesByName(model.Article);
            if (model.Id == 0)
            {
                AccountItems item = new AccountItems
                {
                    AccountId = model.AccountId,
                    ArticleId = article.ArticleId,
                    Payout = model.Price
                };
                _financijeService.AddAcountItem(item);
            }
            return Ok("Ok");
        }

        //[HttpPost("GetArticleItem")]
        //public ActionResult GetArticleItem([FromForm] GridParams g, [FromForm] AccountItemModel search)
        //{
        //    var accountItems = _financijeService.GetAccountItemsByAccountId(search.Id);
        //    var itemsCount = _financijeService.CountAcountItem(search.Id);

        //    var accItemModel = _mapper.Map<AccountItemModel>(accountItems);

        //    return Ok(new GridModelBuilder<AccountItemModel>(g) 
        //    {
        //        PageItems = (IEnumerable<AccountItemModel>)accItemModel,
        //        ItemsCount = itemsCount
        //    }.Build());
        //}


        /// <summary>
        /// Prikaz opisa
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Dodavanje opisa
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddOrEditDescription")]
        public IActionResult AddOrEditDescription([FromBody] DescriptionPreviewModel model)
        {
            string message;
            if (model.DescriptionId != 0)
            {
                var description = _financijeService.GetDescriptionById(model.DescriptionId);
                description.DescriptionName = model.DescriptionName;
                description.DescriptionNameUC = model.DescriptionName.ToUpper();
                _financijeService.EditDescription();
                message = $"OK";
            }
            else
            {
                var description = _financijeService.GetDescriptionByName(model.DescriptionName);
                if (description == null)
                {
                    _financijeService.AddDescription(model.DescriptionName);
                    message = $"OK";
                }
                else
                {
                    return NotFound("Dupli");
                }

            }
            return Ok(message);
        }

        /// <summary>
        /// Brisanje opisa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("DeleteDescriptions")]
        public IActionResult DeleteDescriptions(int Id)
        {
            var details = _financijeService.GetDescriptionById(Id);
            string message;
            if (details != null)
            {
                _financijeService.RemoveDescription(Id);
                message = $"Deleted";
            }
            else
            {
                message = $"Not";
            }
            return Ok(message);
        }

        /// <summary>
        /// Dohvaćanje detalja opisa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetDescriptionDetails")]
        public IActionResult GetDescriptionDetails(int Id)
        {
            DescriptionPreviewModel description = _mapper.Map<DescriptionPreviewModel>(_financijeService.GetDescriptionById(Id));
            var jsonData = new { data = description };
            return Ok(jsonData);
        }

        /// <summary>
        /// Prikaz trgovina
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Dohvaća detalje trgovine
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetStoreDetails")]
        public IActionResult GetStoreDetails(int Id)
        {
            StorePreviewModel store = _mapper.Map<StorePreviewModel>(_financijeService.GetStoreById(Id));
            var jsonData = new { data = store };
            return Ok(jsonData);
        }

        /// <summary>
        /// Dodaje trgovinu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddOrEditStore")]
        public IActionResult AddOrEditStore([FromBody] StorePreviewModel model)
        {
            string message;
            if (model.StoreId != 0)
            {
                var store = _financijeService.GetStoreById(model.StoreId);
                store.StoreName = model.StoreName;
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

        /// <summary>
        /// Briše trgovinu
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("DeleteStores")]
        public IActionResult DeleteStores(int Id)
        {
            var details = _financijeService.GetStoreById(Id);
            string message;
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

        /// <summary>
        /// Vraća podatke o odabranom računu
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetAccountData")]
        public IActionResult GetAccountData(int Id)
        {
            AccountPreviewModel accountData = _mapper.Map<AccountPreviewModel>(_financijeService.GetAccountsById(Id));
            var jsonData = new { data = accountData };
            return Ok(jsonData);
        }


        

        //[HttpPost("GetAccountNumber")]
        //public IActionResult GetAccountNumber([FromBody] AccountDetailsModel model)
        //{
        //    var account = _financijeService.GetAccountsByName(model.AccountNumber);
        //    string message;

        //    if(account == null)
        //    {
        //        message = $"OK";
        //    }
        //    else
        //    {
        //        message = $"Duplo";
        //    }

        //    return Ok(message);
        //}

    }
}
