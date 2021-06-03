using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoTagger.Models;
using GeoTagger.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeoTagger.Web.Areas.User.Pages.Tags
{
    public class EditModel : PageModel
    {
        private readonly ITagRepository tagRepository;

        [BindProperty]
        public Tag Item { get; set; }

        [ViewData]
        public string Title { get; } = "Изменить объект";

        [TempData]
        public string FormResult { get; set; }

        public IActionResult OnGet(Guid id)
        {
            return Page();
        }
    }
}
