using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common
{
    public interface IRepository
    {
        void Add<TModel>(TModel model);
        void Update<TModel>(TModel model);
        void Delete<TModel>(TModel model);
        TModel GetById<TModel>(int id);
        IEnumerable<TModel> GetByName<TModel>(string name);
    }
}
