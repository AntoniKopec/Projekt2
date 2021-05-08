using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurator.Utility;

namespace Restaurator.Pages.Admin.User
{
    [Authorize(Roles = StaticDetails.AdminRole)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
