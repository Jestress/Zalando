using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Zalando.AppLibrary.Messages
{
    public class FacetResult : ObservableObject
    {
        private string filter;
        public string Filter { get { return filter; } set { filter = value; RaisePropertyChanged(); } }

        private ObservableCollection<Facet> facets;
        public ObservableCollection<Facet> Facets
        {
            get { return facets; }
            set { facets = value; RaisePropertyChanged(); }
        }
    }
}
