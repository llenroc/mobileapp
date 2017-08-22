using System;
using Toggl.PrimeRadiant.Models;

namespace Toggl.PrimeRadiant.Realm
{
    internal class WorkspaceFeaturesRealmAdapter : BaseRealmAdapter<RealmWorkspaceFeatureCollection, IDatabaseWorkspaceFeatureCollection>
    {
        public WorkspaceFeaturesRealmAdapter()
            : base(convertToRealm, matchByWorkspaceId)
        {
        }

        private static RealmWorkspaceFeatureCollection convertToRealm(IDatabaseWorkspaceFeatureCollection collection, Realms.Realm realm)
            => collection as RealmWorkspaceFeatureCollection ?? new RealmWorkspaceFeatureCollection(collection, realm);

        private static bool matchByWorkspaceId(RealmWorkspaceFeatureCollection realmCollection, IDatabaseWorkspaceFeatureCollection databaseCollection)
            => realmCollection.WorkspaceId == databaseCollection.WorkspaceId;
    }
}
