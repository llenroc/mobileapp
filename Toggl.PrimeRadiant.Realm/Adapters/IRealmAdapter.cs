using System;
using System.Linq;

namespace Toggl.PrimeRadiant.Realm
{
    internal interface IRealmAdapter<TModel>
        where TModel : IDatabaseSyncable
    {
        IQueryable<TModel> GetAll();

        void Delete(TModel entity);

        TModel Create(TModel entity);

        TModel Update(TModel entity);   
    }
}
