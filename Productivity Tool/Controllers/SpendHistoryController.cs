using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Productivity_Tool.Models;

namespace Productivity_Tool.Controllers
{
    public class SpendHistoryController : Controller
    {
        private readonly SpendItemService _spendItemService;

        public SpendHistoryController(SpendItemService spendItemService)
        {
            _spendItemService = spendItemService;
        }
        public IActionResult Index()
        {
            var viewModel = new SpendHistoryViewModel()
            {
                SpendItems = _spendItemService.GetSpendItems(User.Identity.Name)
            };
            return View(viewModel);
        }
    }
}