using System;
using System.Collections.Generic;
using System.Linq;
using Toggl.PrimeRadiant.Models;
using Toggl.PrimeRadiant.Realm;

namespace Toggl.PrimeRadiant.Tests.Realm
{
    public class TestWorkspaceFeatureCollectionAdapter : IRealmAdapter<IDatabaseWorkspaceFeatureCollection>
    {
        private readonly List<IDatabaseWorkspaceFeatureCollection> list = new List<IDatabaseWorkspaceFeatureCollection>();

        public IDatabaseWorkspaceFeatureCollection Create(IDatabaseWorkspaceFeatureCollection entity)
        {
            if (list.Find(e => e.WorkspaceId == entity.WorkspaceId) != null)
                throw new InvalidOperationException();

            list.Add(entity);

            return entity;
        }

        public IDatabaseWorkspaceFeatureCollection Update(IDatabaseWorkspaceFeatureCollection entity)
        {
            var index = list.FindIndex(e => e.WorkspaceId == entity.WorkspaceId);

            if (index == -1)
                throw new InvalidOperationException();

            list[index] = entity;

            return entity;
        }

        public IQueryable<IDatabaseWorkspaceFeatureCollection> GetAll()
            => list.AsQueryable();

        public void Delete(IDatabaseWorkspaceFeatureCollection entity)
        {
            var worked = list.Remove(entity);
            if (worked) return;

            throw new InvalidOperationException();
        }
    }
}
