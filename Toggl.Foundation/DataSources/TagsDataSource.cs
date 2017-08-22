using System;
using System.Collections.Generic;
using Toggl.Multivac;
using Toggl.PrimeRadiant;
using Toggl.PrimeRadiant.Models;

namespace Toggl.Foundation.DataSources
{
    public class TagsDataSource : ITagsSource
    {
        private readonly IRepository<IDatabaseTag> repository;

        public TagsDataSource(IRepository<IDatabaseTag> repository)
        {
            Ensure.Argument.IsNotNull(repository, nameof(repository));

            this.repository = repository;
        }

        public IObservable<IEnumerable<IDatabaseTag>> GetAll(Func<IDatabaseTag, bool> predicate)
            => repository.GetAll(predicate);
    }
}
