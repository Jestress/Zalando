using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel;
using Windows.UI.Xaml.Navigation;
using Zalando.AppLibrary.DataServices;
using Zalando.UI.Core;

namespace Zalando.UI.ViewModels
{
    /// <summary>
    /// Base ViewModel class that contains core members and functions that a ViewModel can use
    /// </summary>
    /// <typeparam name="T">Type parameter for the Model of the ViewModel</typeparam>
    internal abstract class BaseViewModel<T> : ViewModelBase, IBaseViewModel where T : INotifyPropertyChanged, new()
    {
        /// <summary>
        /// Data services API member
        /// </summary>
        protected internal IApiService ApiService { get; private set; }

        /// <summary>
        /// Navigation services API member
        /// </summary>
        protected internal INavigationService NavigationService { get; private set; }

        private T model;

        /// <summary>
        /// Model of this ViewModel. Models contain all data about ViewModel
        /// </summary>
        public T Model { get { return model; } set { model = value; RaisePropertyChanged(); } }

        protected BaseViewModel()
        {
            Model = new T();

            ApiService = ServiceLocator.Current.GetInstance<IApiService>();
            NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();
        }

        /// <summary>
        /// Activation method that is called every time this ViewModel is invoked. (Through a view)
        /// </summary>
        /// <param name="parameter">Navigation parameter from the previous ViewModel</param>
        public abstract void Activate(object parameter);

        public void InnerActivate(object parameter, NavigationMode navigationMode)
        {
            Activate(parameter);
        }
    }

}
