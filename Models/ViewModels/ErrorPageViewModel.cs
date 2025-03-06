using gms2025.Models.PublishedModels;
using Umbraco.Cms.Core.Web;

namespace GMS2025.Models.ViewModels
{
    public class ErrorPageViewModel : BasePageViewModel<Error>
    {
        public ErrorPageViewModel(Error content) : base(content, StaticServiceProvider.Instance.GetService<IUmbracoContextAccessor>())
        {
        }
    }
}