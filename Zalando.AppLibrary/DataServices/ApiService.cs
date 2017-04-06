using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Windows.Web.Http;
using Zalando.AppLibrary.Messages;

namespace Zalando.AppLibrary.DataServices
{
    /// <summary>
    /// Data service class that performs CRUD operations to the Zalando API
    /// </summary>
    public sealed class ApiService : IApiService
    {
        private const string FacetsOperationQueryString = "https://api.zalando.com/facets?gender={0}&brandFamily={1}&page=1&pageSize=10&fields=filter%2Cfacets.key%2Cfacets.displayName";
        private const string ArticlesOperationQueryString = "https://api.zalando.com/articles?gender={0}&brandFamily={1}&page={2}&pageSize=10";
        private const string BrandFamilyNameFilter = "brandFamilyName";
        private const string MaleGenderParameter = "male";
        private const string FemaleGenderParameter = "female";

        private const int DefaultPageCount = 10;

        private async Task<T> ExecuteOperation<T>(string targetUrl)
        {
            using (var client = new HttpClient())
            {
                var encodedUrl = new Uri(targetUrl);

                var response = await client.GetAsync(encodedUrl);

                var rawResult = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(rawResult);
            }
        }

        /// <summary>
        /// Method to perform a search to the Facets API.
        /// </summary>
        /// <param name="queryText">Query that will be passed to the 'brandFamily' filter</param>
        /// <param name="isMale"></param>
        /// <returns>Returns a collection of facet search results</returns>
        public async Task<ObservableCollection<FacetResult>> SearchFacets(string queryText, bool isMale)
        {
            var genderParameter = isMale ? MaleGenderParameter : FemaleGenderParameter;

            var targetUrl = string.Format(FacetsOperationQueryString, genderParameter, WebUtility.UrlEncode(queryText));

            return await ExecuteOperation<ObservableCollection<FacetResult>>(targetUrl);
        }

        /// <summary>
        /// Method to perform a search to the Articles API.
        /// </summary>
        /// <param name="queryText">Query that will be passed to the 'brandFamily' filter</param>
        /// <param name="isMale"></param>
        /// <param name="pageNumber">Number of requested page</param>
        /// <returns>Returns a collection of article search results</returns>
        public async Task<ArticleSearchResult> SearchArticles(string queryText, bool isMale, int pageNumber)
        {
            var genderParameter = isMale ? MaleGenderParameter : FemaleGenderParameter;

            var targetUrl = string.Format(ArticlesOperationQueryString, genderParameter, WebUtility.UrlEncode(queryText), pageNumber);

            return await ExecuteOperation<ArticleSearchResult>(targetUrl);
        }

        /// <summary>
        /// Performs a search to the Articles API, from a facet result
        /// Facet results contains 'filter' values, this method executes a search regarding to the passed 'filter'
        /// </summary>
        /// <param name="queryText">Query that will be passed to the related 'filter' value</param>
        /// <param name="filterName">'filter' parameter that will be passed to the Articles API</param>
        /// <param name="isMale"></param>
        /// <param name="pageNumber">Number of requested page</param>
        /// <returns>Returns a collection of article search results</returns>
        public async Task<ArticleSearchResult> SearchArticles(string queryText, string filterName, bool isMale, int pageNumber)
        {
            var genderParameter = isMale ? MaleGenderParameter : FemaleGenderParameter;

            var targetUrl = string.Format(ArticlesOperationQueryString, genderParameter, WebUtility.UrlEncode(queryText), pageNumber);

            return await ExecuteOperation<ArticleSearchResult>(targetUrl);
        }
    }
}
