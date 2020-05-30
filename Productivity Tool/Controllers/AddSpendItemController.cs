using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Productivity_Tool.Models;
using Shared.Enums;

namespace Productivity_Tool.Controllers
{
    public class AddSpendItemController : Controller
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly SpendItemService _spendItemService;
        private readonly SpendItemViewModel _viewModel;
        public AddSpendItemController(IHtmlHelper htmlHelper, SpendItemService spendItemService)
        {
            _htmlHelper = htmlHelper;
            _spendItemService = spendItemService;
            _viewModel = new SpendItemViewModel();
        }
        [HttpGet]
        public IActionResult Index()
        {
            _viewModel.SpendItem = new SpendItem()
            {
                Date = DateTime.Now
            };
            _viewModel.Categories = _htmlHelper.GetEnumSelectList<Category>();
            return View(_viewModel);
        }

        [HttpPost]
        public IActionResult Add(SpendItemViewModel viewModel)
        {
            _spendItemService.Add(new SpendItem()
            {
                AmountSpent = viewModel.SpendItem.AmountSpent,
                Category = viewModel.SpendItem.Category,
                Description = viewModel.SpendItem.Description,
                EmailAddress = User.Identity.Name,
                Date = viewModel.SpendItem.Date
            });
            return RedirectToAction("Index");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] SpendItemViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}