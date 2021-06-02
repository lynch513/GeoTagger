using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoTagger.Models;
using GeoTagger.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GeoTagger.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly ITagRepository tagRepository;

        [TempData]
        public string FormResult { get; set; }

        public List<Tag> Items { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITagRepository tagRepository)
        {
            this.logger = logger;
            this.tagRepository = tagRepository;
        }

        public void OnGet()
        {
            Items = tagRepository.GetAll().ToList();
            //Items = new List<Tag> { };
        }
    }
}
