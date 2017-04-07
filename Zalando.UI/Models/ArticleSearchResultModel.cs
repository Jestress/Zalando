using System.Collections.ObjectModel;
using Zalando.AppLibrary.Messages;

namespace Zalando.UI.Models
{
    public class ArticleSearchResultModel : SearchModel
    {
        private ArticleSearchResult searchResult;
        public ArticleSearchResult SearchResult { get { return searchResult; } set { searchResult = value; RaisePropertyChanged(); } }

        private ObservableCollection<ArticleSearchResultItem> searchResultListSource;
        public ObservableCollection<ArticleSearchResultItem> SearchResultListSource { get { return searchResultListSource; } set { searchResultListSource = value; RaisePropertyChanged(); } }

        private int currentPageNumber;
        public int CurrentPageNumber { get { return currentPageNumber; } set { currentPageNumber = value; RaisePropertyChanged(); } }
    }
}
