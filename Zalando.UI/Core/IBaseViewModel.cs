using Windows.UI.Xaml.Navigation;

namespace Zalando.UI.Core
{
    interface IBaseViewModel
    {
        void InnerActivate(object parameter, NavigationMode navigationMode);
    }
}
