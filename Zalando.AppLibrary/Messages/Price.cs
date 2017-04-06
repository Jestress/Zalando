using GalaSoft.MvvmLight;
using Newtonsoft.Json;
namespace Zalando.AppLibrary.Messages
{
    public class Price : ObservableObject
    {
        private string currency;
        public string Currency { get { return currency; } set { currency = value; RaisePropertyChanged(); } }

        private decimal amount;

        [JsonProperty("value")]
        public decimal Amount { get { return amount; } set { amount = value; RaisePropertyChanged(); } }

        private string displayValue;

        [JsonProperty("formatted")]
        public string DisplayValue { get { return displayValue; } set { displayValue = value; RaisePropertyChanged(); } }
    }
}
