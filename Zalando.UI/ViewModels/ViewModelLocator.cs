using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Zalando.AppLibrary.DataServices;
using Zalando.UI.Views;

namespace Zalando.UI.ViewModels
{
    class ViewModelLocator
    {
        public SearchViewModel SearchViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }

        public ArticleSearchResultViewModel ArticleSearchResultViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ArticleSearchResultViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterRuntimeProviders();

            RegisterViewModels();

            RegisterNavigations();
        }

        private static void RegisterNavigations()
        {
            var navService = new NavigationService();

            foreach (var page in ViewCatalog.Pages)
            {
                navService.Configure(page.Key, page.Value);
            }

            SimpleIoc.Default.Register<INavigationService>(() => navService);
        }

        private static void RegisterViewModels()
        {
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<ArticleSearchResultViewModel>();
        }

        /// <summary>
        /// Registers runtime providers.
        /// </summary>
        private static void RegisterRuntimeProviders()
        {
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IApiService, ApiService>();
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
