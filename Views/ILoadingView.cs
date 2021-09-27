using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views
{
    public interface ILoadingView
    {
        int LoadingPercent { get; set; }
        string LoadingText { get; set; }
    }
}
