using System.Linq;
using System.Collections.ObjectModel;
using Zalando.UI.Models;
using Zalando.AppLibrary.Messages;
using System.Threading.Tasks;

namespace Zalando.UI.ViewModels
{
    /// <summary>
    /// ViewModel class for managing search results and pagination of results
    /// </summary>
    internal sealed class ArticleSearchResultViewModel : BaseViewModel<ArticleSearchResultModel>
    {
        /// <summary>
        /// Combines existing search result with the given parameter, updates View regarding new composed data
        /// </summary>
        /// <param name="searchResult">Search result data to be appended to the existing results</param>
        private void AppendResult(ArticleSearchResult searchResult)
        {
            //Since Articles API returns bulk data, process each record to make them more user-friendly
            var interceptorList = searchResult.Articles.SelectMany(unit => unit.Units, ComposeArticleSearchItem);

            //Observable collections do not support AddRange, append each item with a loop
            foreach (var searchResultItem in interceptorList)
            {
                this.Model.SearchResultListSource.Add(searchResultItem);
            }
        }

        /// <summary>
        /// Processes each individual <see cref="ShopArticle"/> item and composes a <see cref="ArticleSearchResultItem"/> to append to the result
        /// Articles API returns data in a JSON tree format, but user would want to see different sizes, different combinations etc. regarding each record, so flatten the Articles API result
        /// </summary>
        /// <param name="article">Individual shop article</param>
        /// <param name="unit">Units information about regarding shop article</param>
        /// <returns></returns>
        private ArticleSearchResultItem ComposeArticleSearchItem(ShopArticle article, ShopArticleUnit unit)
        {
            return new ArticleSearchResultItem { ArticleCode = article.ArticleCode, FormattedCost = unit.Price.DisplayValue, Name = article.Name, ModelId = article.ModelId, Size = unit.Size, MediaUrl = article.Media.Images[0].ThumbNailUrl };
        }

        public override void Activate(object parameter)
        {
            this.Model = parameter as ArticleSearchResultModel;
            this.Model.SearchResultListSource = new ObservableCollection<ArticleSearchResultItem>();

            AppendResult(Model.SearchResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task GetNextResultPage()
        {
            Model.CurrentPageNumber++;

            ArticleSearchResult nextPageData;

            if (Model.SelectedFacet != null && !string.IsNullOrEmpty(Model.SelectedFacet.DisplayName))
            {
                nextPageData = await ApiService.SearchArticles(Model.SelectedFacet.DisplayName, Model.SelectedFacet.Filter, Model.IsMale, Model.CurrentPageNumber);
            }
            else
            {
                nextPageData = await ApiService.SearchArticles(Model.QueryText, Model.IsMale, Model.CurrentPageNumber);
            }

            AppendResult(nextPageData);
        }
    }
}
