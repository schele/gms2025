using gms2025.Models.PublishedModels;
using GMS2025.Business.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace GMS2025.Business.Services
{
    public class SitemapService : ISitemapService
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public SitemapService(IUmbracoContextAccessor umbracoContextAccessor)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public List<IPublishedContent> Pages()
        {
            if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
            {
                var content = umbracoContext.Content;

                if (content != null)
                {
                    var startPage = content.GetAtRoot().DescendantsOrSelf<Start>().FirstOrDefault();

                    if (startPage != null)
                    {
                        return startPage.DescendantsOrSelf<IPublishedContent>()
                            .Where(page => page is IBase basePage).ToList();
                    }
                }
            }

            return [];
        }
    }
}