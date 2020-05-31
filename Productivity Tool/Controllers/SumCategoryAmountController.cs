using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Productivity_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumCategoryAmountController : ControllerBase
    {
        private readonly SpendItemService _spendItemService;

        public SumCategoryAmountController(SpendItemService spendItemService)
        {
            _spendItemService = spendItemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_spendItemService.SumCategorySpendAmounts(User.Identity.Name));
        }
    }
}