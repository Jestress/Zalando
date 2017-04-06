using GalaSoft.MvvmLight;

namespace Zalando.AppLibrary.Messages
{
    public class ArticleSearchResultItem : ObservableObject
    {
        private string articleCode;
        public string ArticleCode { get { return articleCode; } set { articleCode = value; RaisePropertyChanged(); } }

        private string modelId;
        public string ModelId { get { return modelId; } set { modelId = value; RaisePropertyChanged(); } }

        private string name;
        public string Name { get { return name; } set { name = value; RaisePropertyChanged(); } }
        
        private string mediaUrl;
        public string MediaUrl { get { return mediaUrl; } set { mediaUrl = value; RaisePropertyChanged(); } }

        private string size;
        public string Size { get { return size; } set { size = value; RaisePropertyChanged(); } }

        private string formattedCost;
        public string FormattedCost { get { return formattedCost; } set { formattedCost = value; RaisePropertyChanged(); } }
    }
}
