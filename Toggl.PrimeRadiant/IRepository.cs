using System;
using Toggl.Multivac.Models;

namespace Toggl.PrimeRadiant
{
    public interface IRepository<TModel> : IBaseRepository<TModel>
        where TModel : IBaseModel, IDatabaseSyncable
    {
        IObservable<TModel> GetById(long id);
    }
}
