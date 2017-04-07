using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Zalando.AppLibrary.Messages;
using Zalando.UI.Models;
using Zalando.UI.Views;

namespace Zalando.UI.ViewModels
{
    /// <summary>
    /// ViewModel class for managing Search View operations
    /// </summary>
    internal sealed class SearchViewModel : BaseViewModel<SearchModel>
    {
        private RelayCommand searchResultsCommand;
        /// <summary>
        /// Command for processing user search and navigating to the results view.
        /// </summary>
        public RelayCommand SearchResultsCommand
        {
            get
            {
                return searchResultsCommand
                    ?? (searchResultsCommand = new RelayCommand(
                    async () =>
                    {
                        var searchResultModel = new ArticleSearchResultModel { QueryText = Model.QueryText, IsMale = Model.IsMale, CurrentPageNumber = 1 };

                        searchResultModel.SearchResult = await ApiService.SearchArticles(Model.QueryText, Model.IsMale, 1);

                        this.NavigationService.NavigateTo(ViewCatalog.ArticleSearchResultViewKey, searchResultModel);
                    }));
            }
        }

        private RelayCommand provideAutoSuggestionsCommand;
        /// <summary>
        /// Self-invoking command that provides auto-suggest list to the user
        /// </summary>
        public RelayCommand ProvideAutoSuggestionsCommand
        {
            get
            {
                return provideAutoSuggestionsCommand
                    ?? (provideAutoSuggestionsCommand = new RelayCommand(
                    async () =>
                    {
                        //If user deleted the whole search text, then clear results
                        if (string.IsNullOrEmpty(Model.QueryText))
                        {
                            Model.FacetResults = null;
                        }
                        else
                        {
                            //Get data from the Facets API
                            var bulkResult = await ApiService.SearchFacets(Model.QueryText, Model.IsMale);

                            //Since Facets API returns data in bulk (by 'filter'), flatten this data to make it more user-friendly
                            //This line normalizes data so that user can only see 'displayName' values
                            Model.FacetResults = new ObservableCollection<Facet>(bulkResult
                                .Where(CheckDisplayableFacet)
                                .SelectMany(facetResult => facetResult.Facets, (facetResult, facet) => new Facet { Count = facet.Count, DisplayName = facet.DisplayName, Filter = facetResult.Filter, Key = facet.Key })
                                .Where(w => w.DisplayName.ToLower().Contains(Model.QueryText.ToLower())));
                        }
                    }));
            }
        }

        private RelayCommand getFacetDetails;

        /// <summary>
        /// Command for selecting an auto-suggest result and showing results of the related article
        /// </summary>
        public RelayCommand GetFacetDetails
        {
            get
            {
                return getFacetDetails
                    ?? (getFacetDetails = new RelayCommand(
                    async () =>
                    {
                        await ShowResults();
                    }));
            }
        }

        /// <summary>
        /// Filters individual facet result if related facet is displayable to the user
        /// Since, user would not want to see values such "XL", "L", "Garson", etc. provide only logical values to the user
        /// </summary>
        /// <param name="facetResult">A single <see cref="FacetResult"/> entity which will be filtered</param>
        /// <returns></returns>
        private bool CheckDisplayableFacet(FacetResult facetResult)
        {
            return facetResult.Filter.ToLower().Equals("brand") || facetResult.Filter.ToLower().Equals("brandfamily") || facetResult.Filter.ToLower().Equals("category");
        }

        /// <summary>
        /// Method to execute a search and navigate to the <see cref="ArticleSearchResultView"/> view to display detailed result of the search to the user
        /// </summary>
        /// <returns></returns>
        private async Task ShowResults()
        {
            if (Model.SelectedFacet == null)
                return;

            //Initalize Model of the ArticleSearchResult view
            var searchResultModel = new ArticleSearchResultModel { SelectedFacet = Model.SelectedFacet, IsMale = Model.IsMale, CurrentPageNumber = 1 };

            //Populate the Model by passing search results
            searchResultModel.SearchResult = await ApiService.SearchArticles(Model.SelectedFacet.DisplayName, Model.SelectedFacet.Filter, Model.IsMale, 1);

            //Navigate to the ArticleSearchResult view
            this.NavigationService.NavigateTo(ViewCatalog.ArticleSearchResultViewKey, searchResultModel);
        }

        public override void Activate(object parameter)
        {
            //Set default value on start-up
            Model.IsMale = true;
        }
    }
}
