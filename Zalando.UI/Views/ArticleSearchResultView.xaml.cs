using Windows.UI.Xaml.Controls;
using Zalando.UI.Core;
using Zalando.UI.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zalando.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArticleSearchResultView : BasePage
    {
        public ArticleSearchResultView()
        {
            this.InitializeComponent();
        }
        
        private async void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            var senderScroll = sender as ScrollViewer;

            //Get ViewModel from DataContext
            var viewModel = this.DataContext as ArticleSearchResultViewModel;

            //Calculate current scroll position
            var verticalOffset = senderScroll.VerticalOffset;
            var maxVerticalOffset = senderScroll.ScrollableHeight;

            if (maxVerticalOffset < 0 ||
                verticalOffset == maxVerticalOffset)
            {
                // Scrolled to bottom, get the next page from API
                await viewModel.GetNextResultPage();
            }
        }
    }
}
