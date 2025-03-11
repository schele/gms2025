using gms2025.Models.PublishedModels;
using GMS2025.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace GMS2025.Controllers
{
    public class LoginController : RenderController
    {
        public LoginController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }

        public override IActionResult Index()
        {
            var loginPage = CurrentPage as Login;

            if (loginPage != null)
            {
                var model = new LoginPageViewModel(loginPage);

                return CurrentTemplate(model);
            }

            return NotFound();
        }
    }
}