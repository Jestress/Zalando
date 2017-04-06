using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Zalando.AppLibrary.Messages;

namespace Zalando.UI.Models
{
    public class SearchModel : ObservableObject
    {
        private string queryText;
        public string QueryText { get { return queryText; } set { queryText = value; RaisePropertyChanged(); RaisePropertyChanged("SearchEnabled"); } }

        public bool SearchEnabled { get { return !string.IsNullOrEmpty(this.QueryText); } }

        private bool isMale;
        public bool IsMale { get { return isMale; } set { isMale = value; RaisePropertyChanged(); } }

        private bool isFemale;
        public bool IsFemale { get { return isFemale; } set { isFemale = value; RaisePropertyChanged(); } }

        private Facet selectedFacet;
        public Facet SelectedFacet { get { return selectedFacet; } set { selectedFacet = value; RaisePropertyChanged(); } }

        private ObservableCollection<Facet> facetResults;
        public ObservableCollection<Facet> FacetResults { get { return facetResults; } set { facetResults = value; RaisePropertyChanged(); } }
    }
}
