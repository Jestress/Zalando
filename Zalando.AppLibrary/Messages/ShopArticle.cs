using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Zalando.AppLibrary.Messages
{
    public class ShopArticle : ObservableObject
    {
        private string articleCode;
        public string ArticleCode { get { return articleCode; } set { articleCode = value; RaisePropertyChanged(); } }

        private string modelId;
        public string ModelId { get { return modelId; } set { modelId = value; RaisePropertyChanged(); } }

        private string name;
        public string Name { get { return name; } set { name = value; RaisePropertyChanged(); } }

        private string shopUrl;
        public string ShopUrl { get { return shopUrl; } set { shopUrl = value; RaisePropertyChanged(); } }

        private ShopArticleMedia media;
        public ShopArticleMedia Media { get { return media; } set { media = value; RaisePropertyChanged(); } }

        private bool isAvailable;
        public bool IsAvailable { get { return isAvailable; } set { isAvailable = value; RaisePropertyChanged(); } }

        private ObservableCollection<ShopArticleUnit> units;
        public ObservableCollection<ShopArticleUnit> Units { get { return units; } set { units = value; RaisePropertyChanged(); } }

        private string formattedCost;
        public string FormattedCost { get { return formattedCost; } set { formattedCost = value; RaisePropertyChanged(); } }
    }

    public class ShopArticleMedia : ObservableObject
    {
        private ObservableCollection<ShopArticleImage> images;

        public ObservableCollection<ShopArticleImage> Images { get { return images; } set { images = value; RaisePropertyChanged(); } }
    }

    public class ShopArticleImage : ObservableObject
    {
        private string thumbNailUrl;

        [JsonProperty("thumbnailHdUrl")]
        public string ThumbNailUrl { get { return thumbNailUrl; } set { thumbNailUrl = value; RaisePropertyChanged(); } }
    }
}
