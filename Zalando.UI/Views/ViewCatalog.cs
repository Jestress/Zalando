using System;
using System.Collections.Generic;

namespace Zalando.UI.Views
{
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
