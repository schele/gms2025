using gms2025.Models.PublishedModels;
using Umbraco.Cms.Core.Web;

namespace GMS2025.Models.ViewModels
{
    public class StartPageViewModel : BasePageViewModel<Start>
    {
        public StartPageViewModel(Start content) : base(content, StaticServiceProvider.Instance.GetService<IUmbracoContextAccessor>())
        {
        }
    }
}