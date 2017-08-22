using System;
using Toggl.PrimeRadiant.Models;

namespace Toggl.PrimeRadiant
{
    public interface IWorkspaceFeatureCollectionsRepository : IBaseRepository<IDatabaseWorkspaceFeatureCollection>
    {
        IObservable<IDatabaseWorkspaceFeatureCollection> GetByWorkspaceId(long id);
    }
}
