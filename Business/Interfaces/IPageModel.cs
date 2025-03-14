using Umbraco.Cms.Core.Models.PublishedContent;

namespace GMS2025.Business.Interfaces
{
    public interface IPageModel : IPublishedContent
    {
        IPublishedContent Content { get; }
    }
}