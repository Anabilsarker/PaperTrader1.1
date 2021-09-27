using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using AppDatabase;
using Views;

namespace Services.Domain
{
    public class WatchRowServices : IWatchRowRepository, IWatchRowValidation
    {
        IMainFormView _mainFormView;
        public bool IsValid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public WatchRowServices(IMainFormView view)
        {
            _mainFormView = view;
        }

        public void Add<TModel>(TModel model)
        {
            
        }
        public async void Add(WatchRow row)
        {
            //Validate(row);
            await ApiAccess.ConnectionToApi.Instance.xts.Subscribe((int)row.exchangeSegment, row.instrumentId);
            
            Inventory.Instance().watches.Add(row);
            Console.WriteLine(Inventory.Instance().watches.Count);
        }

        public void Delete<TModel>(TModel model)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
