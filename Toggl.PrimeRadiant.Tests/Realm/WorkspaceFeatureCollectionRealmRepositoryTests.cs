using System;
using System.Linq;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Toggl.PrimeRadiant.Realm;

namespace Toggl.PrimeRadiant.Tests.Realm
{
    public class WorkspaceFeatureCollectionRealmRepositoryTests : BaseRepositoryTests<WorkspaceFeatureCollectionTestModel>
    {
        protected override IBaseRepository<WorkspaceFeatureCollectionTestModel> BaseRepository { get; }
            = new WorkspaceFeatureCollectionsRepositoryTestWrapper();

        protected override WorkspaceFeatureCollectionTestModel GetModelWith(int id)
            => new WorkspaceFeatureCollectionTestModel { WorkspaceId = id };

        private class WorkspaceFeatureCollectionsRepositoryTestWrapper : IBaseRepository<WorkspaceFeatureCollectionTestModel>
        {
            private WorkspaceFeatureCollectionsRepository repository;

            public WorkspaceFeatureCollectionsRepositoryTestWrapper()
            {
                this.repository = new WorkspaceFeatureCollectionsRepository(new TestWorkspaceFeatureCollectionAdapter()); ;
            }

            public IObservable<WorkspaceFeatureCollectionTestModel> Create(WorkspaceFeatureCollectionTestModel entity)
                => repository.Create(entity).Cast<WorkspaceFeatureCollectionTestModel>();

            public IObservable<Unit> Delete(WorkspaceFeatureCollectionTestModel entity)
                => repository.Delete(entity);

            public IObservable<IEnumerable<WorkspaceFeatureCollectionTestModel>> GetAll()
                => repository.GetAll().Select(all => all.Cast<WorkspaceFeatureCollectionTestModel>());

            public IObservable<IEnumerable<WorkspaceFeatureCollectionTestModel>> GetAll(Func<WorkspaceFeatureCollectionTestModel, bool> predicate)
                => repository.GetAll(model => predicate((WorkspaceFeatureCollectionTestModel)model)).Select(all => all.Cast<WorkspaceFeatureCollectionTestModel>());

            public IObservable<WorkspaceFeatureCollectionTestModel> Update(WorkspaceFeatureCollectionTestModel entity)
                => repository.Update(entity).Cast<WorkspaceFeatureCollectionTestModel>();
        }
    }
}
