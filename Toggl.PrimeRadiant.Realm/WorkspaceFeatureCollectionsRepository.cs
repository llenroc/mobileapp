using System;
using System.Linq;
using System.Reactive.Linq;
using Toggl.Multivac;
using Toggl.PrimeRadiant.Exceptions;
using Toggl.PrimeRadiant.Models;

namespace Toggl.PrimeRadiant.Realm
{
    internal sealed class WorkspaceFeatureCollectionsRepository : BaseStorage<IDatabaseWorkspaceFeatureCollection>, IWorkspaceFeatureCollectionsRepository
    {
        public WorkspaceFeatureCollectionsRepository(IRealmAdapter<IDatabaseWorkspaceFeatureCollection> adapter)
            : base(adapter)
        {
        }

        public IObservable<IDatabaseWorkspaceFeatureCollection> Create(IDatabaseWorkspaceFeatureCollection entity)
        {
            Ensure.Argument.IsNotNull(entity, nameof(entity));

            return Observable
                .Start(() => Adapter.Create(entity))
                .Catch<IDatabaseWorkspaceFeatureCollection, Exception>(ex =>
                    Observable.Throw<IDatabaseWorkspaceFeatureCollection>(new DatabaseException(ex)));
        }

        public IObservable<IDatabaseWorkspaceFeatureCollection> GetByWorkspaceId(long id)
            => CreateObservable(() => Adapter.GetAll().Single(x => x.WorkspaceId == id));
    }
}
