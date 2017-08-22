﻿using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Toggl.Multivac.Extensions;
using Xunit;

namespace Toggl.PrimeRadiant.Tests
{
    public abstract class BaseRepositoryTests<TTestModel> : BaseStorageTests<TTestModel>
        where TTestModel : class, IDatabaseSyncable, new()
    {
        protected sealed override IObservable<TTestModel> Create(TTestModel testModel)
            => BaseRepository.Create(testModel);

        protected sealed override IObservable<TTestModel> Update(TTestModel testModel)
            => BaseRepository.Update(testModel);

        protected sealed override IObservable<Unit> Delete(TTestModel testModel)
            => BaseRepository.Delete(testModel);

        protected abstract IBaseRepository<TTestModel> BaseRepository { get; }

        [Fact]
        public async Task TheGetAllMethodReturnsAnEmptyListIfThereIsNothingOnTheRepository()
        {
            var entities = await BaseRepository.GetAll(_ => true);
            entities.Count().Should().Be(0);
        }

        [Fact]
        public async Task TheGetAllMethodReturnsAllItemsThatMatchTheQuery()
        {
            const int numberOfItems = 5;

            await Enumerable.Range(0, numberOfItems)
                            .Select(GetModelWith)
                            .Select(async model => await BaseRepository.Create(model))
                            .Apply(Task.WhenAll);

            var entities = await BaseRepository.GetAll(_ => true);
            entities.Count().Should().Be(numberOfItems);
        }
    }
}
