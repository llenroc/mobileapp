using System;
using System.Collections.Generic;
using Toggl.PrimeRadiant.Models;

namespace Toggl.Foundation.DataSources
{
    public interface ITagsSource
    {
        IObservable<IEnumerable<IDatabaseTag>> GetAll(Func<IDatabaseTag, bool> predicate);
    }
}