using System.Collections.Generic;
using Toggl.Multivac.Models;

namespace Toggl.PrimeRadiant.Models
{
    public interface IDatabaseWorkspaceFeatureCollection : IWorkspaceFeatureCollection
    {
        IEnumerable<IDatabaseWorkspaceFeature> DatabaseFeatures { get; }
    }
}
