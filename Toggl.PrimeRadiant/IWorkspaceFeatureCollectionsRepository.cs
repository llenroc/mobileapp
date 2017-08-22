using System;
using Toggl.PrimeRadiant.Models;

namespace Toggl.PrimeRadiant
{
    public interface IWorkspaceFeatureCollectionsRepository
    {
        IObservable<IDatabaseWorkspaceFeatureCollection> Create(IDatabaseWorkspaceFeatureCollection entity);

        IObservable<IDatabaseWorkspaceFeatureCollection> GetByWorkspaceId(long id);
    }
}
