using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Productivity_Tool.Models;
using Shared.Enums;

namespace Productivity_Tool.Controllers
{
    public class SpendItemsController : Controller
    {
        private readonly IHtmlHelper _htmlHelper;

        public SpendItemsController(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new SpendItemViewModel();
            viewModel.Categories = _htmlHelper.GetEnumSelectList<Category>();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(SpendItemViewModel viewModel)
        {
            return null;
        }

    }
}