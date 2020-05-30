using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Enums;

namespace Productivity_Tool.Models
{
    public class SpendItemViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public SpendItem SpendItem { get; set; }

    }
}
