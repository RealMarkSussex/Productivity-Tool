using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Productivity_Tool.Models;
using Shared.Enums;

namespace Productivity_Tool.Controllers
{
    public class EditSpendItemController : Controller
    {
        private readonly SpendItemService _spendItemService;
        private readonly IHtmlHelper _htmlHelper;

        public EditSpendItemController(SpendItemService spendItemService, IHtmlHelper htmlHelper)
        {
            _spendItemService = spendItemService;
            _htmlHelper = htmlHelper;
        }
        public IActionResult Index(Guid id)
        {
            var viewModel = new SpendItemViewModel
            {
                Categories = _htmlHelper.GetEnumSelectList<Category>(),
                SpendItem = _spendItemService.GetSpendItem(id)
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(SpendItemViewModel viewModel)
        {
            viewModel.SpendItem.EmailAddress = User.Identity.Name;
            _spendItemService.Update(viewModel.SpendItem);
            return RedirectToAction("Index", "SpendHistory");
        }
    }
}