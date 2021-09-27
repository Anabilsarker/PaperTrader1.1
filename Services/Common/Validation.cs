using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common
{
    public class Validation : IValidation
    {
        public virtual bool IsValid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual void Validate<TDataModel>(TDataModel model)
        {
            throw new NotImplementedException();
        }
    }
}
