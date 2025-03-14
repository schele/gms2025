﻿using gms2025.Models.PublishedModels;
using GMS2025.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace GMS2025.Controllers
{
    public class StartController : RenderController
    {
        public StartController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }

        public override IActionResult Index()
        {
            var startPage = CurrentPage as Start;

            if (startPage != null)
            {
                var model = new StartPageViewModel(startPage);

                return CurrentTemplate(model);
            }

            return NotFound();
        }
    }
}