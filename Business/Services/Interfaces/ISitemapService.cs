using Umbraco.Cms.Core.Models.PublishedContent;

namespace GMS2025.Business.Services.Interfaces
{
    public interface ISitemapService
    {
        List<IPublishedContent> Pages();
    }
}