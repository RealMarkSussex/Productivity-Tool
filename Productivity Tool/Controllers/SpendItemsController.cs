﻿using System;
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
    public class SpendItemsController : Controller
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly SpendItemService _spendItemService;
        private SpendItemViewModel _viewModel;
        public SpendItemsController(IHtmlHelper htmlHelper, SpendItemService spendItemService)
        {
            _htmlHelper = htmlHelper;
            _spendItemService = spendItemService;
            _viewModel = new SpendItemViewModel();
        }
        [HttpGet]
        public IActionResult Index()
        {
            _viewModel.Categories = _htmlHelper.GetEnumSelectList<Category>();
            return View(_viewModel);
        }

        [HttpPost]
        public IActionResult Add(SpendItemViewModel viewModel)
        {
            var lol = this.User.Identity.Name;
            _spendItemService.Add(new SpendItem()
            {
                AmountSpent = viewModel.AmountSpent,
                Category = viewModel.Category,
                Description = viewModel.Description,
                EmailAddress = User.Identity.Name
            });
            return RedirectToAction("Index");
        }

    }
}