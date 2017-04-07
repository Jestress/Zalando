using System;
using System.Collections.Generic;

namespace Zalando.UI.Views
{
    /// <summary>
    /// Singleton class that holds registered views inside the application
    /// </summary>
    public static class ViewCatalog
    {
        public static readonly string SearchViewKey = "SearchView";
        public static readonly string ArticleSearchResultViewKey = "ArticleSearchResultView";

        public static readonly Dictionary<string, Type> Pages = new Dictionary<string, Type>();

        static ViewCatalog()
        {
            Pages.Add(SearchViewKey, typeof(SearchView));
            Pages.Add(ArticleSearchResultViewKey, typeof(ArticleSearchResultView));
        }
    }
}
