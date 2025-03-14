using gms2025.Models.PublishedModels;
using GMS2025.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using GMS2025.Business.Services.Interfaces;

namespace GMS2025.Controllers
{
    public class SitemapController : RenderController
    {
        private readonly ISitemapService _sitemapService;

        public SitemapController(ISitemapService sitemapService, ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _sitemapService = sitemapService;
        }

        public override IActionResult Index()
        {
            var sitemap = CurrentPage as Sitemap;

            if (sitemap != null)
            {
                var model = new SitemapViewModel(sitemap)
                {
                    Pages = _sitemapService.Pages()
                };

                return CurrentTemplate(model);
            }

            return null;
        }
    }
}