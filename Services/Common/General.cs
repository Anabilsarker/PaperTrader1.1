using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiAccess;

namespace Services.Common
{
    public class General
    {
        
        public General()
        {
            LoadComponent();
        }
        public void LoadComponent()
        {

            ConnectionToApi.Instance.ConfigureApi();
            
            //Console.ReadKey();
        }
    }
}
