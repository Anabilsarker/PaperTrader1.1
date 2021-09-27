using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Common;
using Domain.Models;

namespace Services.Domain
{
    public class SecurityServices : ISecurityRepository, ISecurityValidation
    {
        bool IValidation.IsValid { get; set; }

        public void Add<TModel>(TModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete<TModel>(TModel model)
        {
            throw new NotImplementedException();
        }
        public Security Get(int instrumentId)
        {
            Security ret = new Security();
            foreach(var security in AppDatabase.Inventory.Instance().securities)
            {
                if(security.exchangeInstrumentID == instrumentId)
                {
                    ret = security;
                }
            }
            if(ret.exchangeInstrumentID == 0)
            {
                throw new Exception("Instrument not found in contract.");
            }
            return ret;
        }
        public TModel GetById<TModel>(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetByName<TModel>(string name)
        {
            throw new NotImplementedException();
        }

        public void Update<TModel>(TModel model)
        {
            throw new NotImplementedException();
        }

        public void Validate<TDataModel>(TDataModel model) 
        {
            try
            {
                
            }
            catch
            {
                throw new ArgumentException($"Exception occured at {model.ToString()}");
            }
            finally
            {
                
            }
            
        }
    }
}
