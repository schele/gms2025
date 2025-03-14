using gms2025.Models.PublishedModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace GMS2025.Models.ViewModels
{
    public class SitemapViewModel : BasePageViewModel<Sitemap>
    {
        public SitemapViewModel(Sitemap content) : base(content, StaticServiceProvider.Instance.GetService<IUmbracoContextAccessor>())
        {
        }

        public List<IPublishedContent> Pages { get; set; }
    }
}