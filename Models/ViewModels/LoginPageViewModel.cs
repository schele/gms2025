using gms2025.Models.PublishedModels;
using Umbraco.Cms.Core.Web;

namespace GMS2025.Models.ViewModels
{
    public class LoginPageViewModel : BasePageViewModel<Login>
    {
        public LoginPageViewModel(Login content) : base(content, StaticServiceProvider.Instance.GetService<IUmbracoContextAccessor>())
        {
        }
    }
}