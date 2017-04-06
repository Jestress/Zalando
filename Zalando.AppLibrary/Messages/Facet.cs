using GalaSoft.MvvmLight;

namespace Zalando.AppLibrary.Messages
{
    public class Facet : ObservableObject
    {

        private string filter;
        public string Filter { get { return filter; } set { filter = value; RaisePropertyChanged(); } }

        private string key;
        public string Key { get { return key; } set { key = value; RaisePropertyChanged(); } }

        private string displayName;
        public string DisplayName { get { return displayName; } set { displayName = value; RaisePropertyChanged(); } }

        private long count;
        public long Count { get { return count; } set { count = value; RaisePropertyChanged(); } }
    }
}
