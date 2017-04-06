using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Zalando.AppLibrary.Messages;

namespace Zalando.AppLibrary.DataServices
{
    public interface IApiService
    {
        Task<ObservableCollection<FacetResult>> SearchFacets(string queryText, bool isMale);

        Task<ArticleSearchResult> SearchArticles(string queryText, bool isMale, int pageNumber);

        Task<ArticleSearchResult> SearchArticles(string queryText, string filterName, bool isMale, int pageNumber);
    }
}
