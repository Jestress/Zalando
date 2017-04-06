using GalaSoft.MvvmLight;

namespace Zalando.AppLibrary.Messages
{
    public class ShopArticleUnit : ObservableObject
    {
        private string id;
        public string Id { get { return id; } set { id = value; RaisePropertyChanged(); } }

        private string size;
        public string Size { get { return size; } set { size = value; RaisePropertyChanged(); } }

        private Price price;
        public Price Price { get { return price; } set { price = value; RaisePropertyChanged(); } }
    }
}
