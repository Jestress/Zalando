using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Zalando.AppLibrary.Messages
{
    public class ArticleSearchResult : ObservableObject
    {
        private ObservableCollection<ShopArticle> articles;

        [JsonProperty("content")]
        public ObservableCollection<ShopArticle> Articles { get { return articles; } set { articles = value; RaisePropertyChanged(); } }

        private long totalElements;
        public long TotalElements { get { return totalElements; } set { totalElements = value; RaisePropertyChanged(); } }

        private int totalPages;
        public int TotalPages { get { return totalPages; } set { totalPages = value; RaisePropertyChanged(); } }

        private int pageNumber;
        public int PageNumber { get { return pageNumber; } set { pageNumber = value; RaisePropertyChanged(); } }

        private int pageSize;
        public int PageSize { get { return pageSize; } set { pageSize = value; RaisePropertyChanged(); } }
    }
}
