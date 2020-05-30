using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Productivity_Tool.Models;
using SpendItem = BusinessLogic.Models.SpendItem;

namespace Productivity_Tool.Controllers
{
    public class DeleteSpendItemController : Controller
    {
        private readonly SpendItemService _spendItemService;

        public DeleteSpendItemController(SpendItemService spendItemService)
        {
            _spendItemService = spendItemService;
        }
        public IActionResult Index(Guid id)
        {
            return View(_spendItemService.GetSpendItem(id));
        }

        [HttpPost]
        public IActionResult Delete(SpendItem viewModel)
        {
            _spendItemService.Delete(viewModel.SpendItemId);
            return RedirectToAction("Index", "SpendHistory");
        }
    }
}