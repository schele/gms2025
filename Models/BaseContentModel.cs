using gms2025.Models.PublishedModels;
using System.Globalization;
using Umbraco.Cms.Api.Management.Controllers.Language.Item;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;

namespace GMS2025.Models
{
    public class BaseContentModel : PublishedContentModel
    {
        private readonly ILanguageService _languageService;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public BaseContentModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
            _umbracoContextAccessor = StaticServiceProvider.Instance.GetService<IUmbracoContextAccessor>();
            _languageService = StaticServiceProvider.Instance.GetService<ILanguageService>();
        }

        public CultureInfo CurrentCultureInfo()
        {
            var cultureName = CultureInfo.CurrentCulture.Name;
            var cultureInfo = new CultureInfo(cultureName);

            return cultureInfo;
        }

        public async Task<List<LanguageModel>> GetLanguageMenuAsync()
        {
            if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
            {
                var pages = new List<LanguageModel>();
                var languages = await _languageService.GetAllAsync();
                var content = umbracoContext.Content;

                foreach (var language in languages)
                {
                    var startPage = content?.GetAtRoot().FirstOrDefault(p => p.Cultures.ContainsKey(language.IsoCode));
                    var cultureInfo = new CultureInfo(language.IsoCode);

                    if (startPage != null)
                    {
                        var languageModel = new LanguageModel
                        {
                            Name = cultureInfo.NativeName.ToFirstUpper(),
                            Url = startPage.Url(language.IsoCode)
                        };

                        pages.Add(languageModel);
                    }
                }

                return pages;
            }

            return [];
        }

        public Start? StartPage
        {
            get
            {
                if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
                {
                    var content = umbracoContext.Content;

                    return content?.GetAtRoot().DescendantsOrSelf<Start>().FirstOrDefault();
                }

                return null;
            }
        }

        public Login? LoginPage
        {
            get
            {
                if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
                {
                    var content = umbracoContext.Content;

                    return content?.GetAtRoot().DescendantsOrSelf<Login>().FirstOrDefault();
                }

                return null;
            }
        }
    }
}