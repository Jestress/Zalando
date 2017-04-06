using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Zalando.AppLibrary.Messages;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Zalando.UI.Controls
{
    public sealed partial class ResultItemControl : UserControl
    {
        /// <summary>
        /// The <see cref="ArticleSearchResultItem" /> dependency property's name.
        /// </summary>
        public const string ArticleSearchResultItemPropertyName = "ArticleSearchResultItem";

        /// <summary>
        /// Gets or sets the value of the <see cref="ArticleSearchResultItem" />
        /// property. This is a dependency property.
        /// </summary>
        public ArticleSearchResultItem ArticleSearchResultItem
        {
            get
            {
                return (ArticleSearchResultItem)GetValue(ArticleSearchResultItemProperty);
            }
            set
            {
                SetValue(ArticleSearchResultItemProperty, value);
            }
        }

        /// <summary>
        /// Identifies the <see cref="ArticleSearchResultItem" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ArticleSearchResultItemProperty = DependencyProperty.Register(
            ArticleSearchResultItemPropertyName,
            typeof(ArticleSearchResultItem),
            typeof(ResultItemControl),
            new PropertyMetadata(null));

        public ResultItemControl()
        {
            this.InitializeComponent();
        }
    }
}
