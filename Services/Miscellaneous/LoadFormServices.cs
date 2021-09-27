using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Miscellaneous
{
    class LoadFormServices
    {
        Views.ILoadingView loadingView;
        LoadFormServices(Views.ILoadingView view)
        {
            loadingView = view;
        }

        public void UpdateLoadingText(string text)
        {
            loadingView.LoadingText = text;
        }

        public void UpdateLoadingPercent(int percent)
        {
            loadingView.LoadingPercent = percent;
        }
    }
}
