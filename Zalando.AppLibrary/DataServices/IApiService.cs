using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Zalando.AppLibrary.Messages;

namespace Zalando.AppLibrary.DataServices
{
    public interface IApiService
    {
        /// <summary>
        /// Method to perform a search to the Facets API.
        /// </summary>
        /// <param name="queryText">Query that will be passed to the 'brandFamily' filter</param>
        /// <param name="isMale"></param>
        /// <returns>Returns a collection of facet search results</returns>
        Task<ObservableCollection<FacetResult>> SearchFacets(string queryText, bool isMale);

        /// <summary>
        /// Method to perform a search to the Articles API.
        /// </summary>
        /// <param name="queryText">Query that will be passed to the 'brandFamily' filter</param>
        /// <param name="isMale"></param>
        /// <param name="pageNumber">Number of requested page</param>
        /// <returns>Returns a collection of article search results</returns>
        Task<ArticleSearchResult> SearchArticles(string queryText, bool isMale, int pageNumber);

        /// <summary>
        /// Performs a search to the Articles API, from a facet result.
        /// Facet results contains 'filter' values, this method executes a search regarding to the passed 'filter'
        /// </summary>
        /// <param name="queryText">Query that will be passed to the related 'filter' value</param>
        /// <param name="filterName">'filter' parameter that will be passed to the Articles API</param>
        /// <param name="isMale"></param>
        /// <param name="pageNumber">Number of requested page</param>
        /// <returns>Returns a collection of article search results</returns>
        Task<ArticleSearchResult> SearchArticles(string queryText, string filterName, bool isMale, int pageNumber);
    }
}
