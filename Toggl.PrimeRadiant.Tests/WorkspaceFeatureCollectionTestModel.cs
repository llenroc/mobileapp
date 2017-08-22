using System;
using System.Collections.Generic;
using Toggl.Multivac;
using Toggl.Multivac.Models;
using Toggl.PrimeRadiant.Models;

namespace Toggl.PrimeRadiant.Tests
{
    public sealed class WorkspaceFeatureCollectionTestModel : IDatabaseWorkspaceFeatureCollection
    {
        public bool IsDirty { get; set; }

        public long WorkspaceId { get; set; }

        public IDatabaseWorkspace Workspace => null;

        public IEnumerable<IDatabaseWorkspaceFeature> DatabaseFeatures => null;

        public IEnumerable<IWorkspaceFeature> Features => null;

        public bool IsEnabled(WorkspaceFeatureId feature) => false;
    }
}