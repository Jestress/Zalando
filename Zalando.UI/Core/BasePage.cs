using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Zalando.UI.Core
{
    public class BasePage : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var viewModel = DataContext as IBaseViewModel;
            if (viewModel != null)
                viewModel.InnerActivate(e.Parameter, e.NavigationMode);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }
    }
}
