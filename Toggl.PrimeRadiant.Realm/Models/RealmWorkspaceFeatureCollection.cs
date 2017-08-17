using System.Collections.Generic;
using System.Linq;
using Realms;
using Toggl.Multivac;
using Toggl.Multivac.Models;
using Toggl.PrimeRadiant.Models;

namespace Toggl.PrimeRadiant.Realm
{
    internal class RealmWorkspaceFeatureCollection : RealmObject, IDatabaseWorkspaceFeatureCollection
    {
        public long WorkspaceId { get; set; }

        public IList<RealmWorkspaceFeature> RealmWorkspaceFeatures { get; }

        public IEnumerable<IDatabaseWorkspaceFeature> DatabaseFeatures
            => RealmWorkspaceFeatures?.Cast<IDatabaseWorkspaceFeature>().ToList() ?? new List<IDatabaseWorkspaceFeature>();

        public IEnumerable<IWorkspaceFeature> Features
            => DatabaseFeatures.ToList<IWorkspaceFeature>();

        public bool IsEnabled(WorkspaceFeatureId feature)
            => Features.Any(f => f.FeatureId == feature && f.Enabled);
    }
}
