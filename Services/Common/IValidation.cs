using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common
{
    interface IValidation
    {
        bool IsValid { get; set; }
        void Validate<TDataModel>(TDataModel model);
    }
}
