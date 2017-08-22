using System;
using System.Collections.Generic;
using System.Reactive;

namespace Toggl.PrimeRadiant
{
    public interface IBaseRepository<TModel>
    {
        IObservable<TModel> Create(TModel entity);
        IObservable<TModel> Update(TModel entity);
        IObservable<Unit> Delete(TModel entity);
        IObservable<IEnumerable<TModel>> GetAll();
        IObservable<IEnumerable<TModel>> GetAll(Func<TModel, bool> predicate);
    }
}
