using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Delete()
        {
            return null;
        }
    }
}